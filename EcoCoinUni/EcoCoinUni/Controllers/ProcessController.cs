using EcoCoinUni.Contexts;
using EcoCoinUni.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoCoinUni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProcessController : ControllerBase
    {
        public AppDbContext _context;

        public ProcessController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Start/{userId}")]
        public async Task<IActionResult> StartSave(double Latitude, double Longitude, int transportId, string userId)
        {
            var activeProcess = await _context.histories.FirstOrDefaultAsync(u => u.UserId == userId && u.Status == false);

            if (activeProcess != null)
            {
                return Ok(activeProcess.Id);
            }

            var data = new Histories
            {
                From = Latitude + "/" + Longitude,
                To = "0/0",
                RoadLenght = 0000,
                Speed = 0000,
                Time = 0000,
                TransportId = transportId,
                Token = 0000,
                CreateTime = DateTime.Now,
                Status = false,
                UserId = userId,
             };

            await _context.histories.AddAsync(data);
            await _context.SaveChangesAsync();

            return Ok(data.Id);
        }

        [HttpGet("Get/{historyId}")]
        public async Task<IActionResult> GetCurrentData(double Latitude, double Longitude, int historyId)
        {
            var data = await _context.histories.FirstOrDefaultAsync(u => u.Id == historyId && u.Status == false);

            var road = GeoDistanceCalculate.CalculateDistance(Convert.ToDouble(data.From.Split('/')[0]), Convert.ToDouble(data.From.Split('/')[1]), Latitude, Longitude);

            var item = new
            {
                StartTime = data.CreateTime,
                CurrentTime = DateTime.Now,
                Road = road,
                Time = (DateTime.Now - data.CreateTime).TotalHours,
            };

            return Ok(item);
        }

        [HttpPut("End/{historyId}")]
        public async Task<IActionResult> SaveHistory(double Latitude, double Longitude, int historyId)
        {
            var data = await _context.histories.FirstOrDefaultAsync(u => u.Id == historyId && u.Status == false);

            var roadKm = GeoDistanceCalculate.CalculateDistance(Convert.ToDouble(data.From.Split('/')[0]), Convert.ToDouble(data.From.Split('/')[1]), Latitude, Longitude);
            var roadTime = (DateTime.Now - data.CreateTime).TotalHours;
            var roadSpeed = Convert.ToInt32(roadKm / roadTime);
            var token = Finder.CalculateToken(data.TransportId, roadKm, roadSpeed, _context.transportTypes.FirstOrDefault(u => data.TransportId == u.Id).TokenPerWay, data.CreateTime, DateTime.Now);

            data.To = Latitude + "/" + Longitude;
            data.RoadLenght = roadKm;
            data.Time = roadTime;
            data.Status = true;
            data.Speed = roadSpeed;
            data.Token = token;
            data.UpdateTime = DateTime.Now;

            var userData = await _context.appUsers.FirstOrDefaultAsync(u => u.Id == data.UserId) ;

            userData.AllToken += token;

            await _context.SaveChangesAsync();

            return NoContent();

        }

    }

    public static class GeoDistanceCalculate
    {
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private static double ToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }
    }

    public static class Finder
    {
        public static int CalculateToken(int id, double roadLenght, double speed, int perRoadToken, DateTime dateTime1, DateTime dateTime2)
        {
            switch (id)
            {
                case 1:
                    if (roadLenght > 1 && (dateTime2 - dateTime1).TotalMinutes > 20)
                    {
                        if(speed !> 6 && speed > 0)
                        {
                            return Convert.ToInt32(roadLenght) * perRoadToken;
                        }
                    }
                    return 0;
                case 2:
                    if (roadLenght > 2 && (dateTime2 - dateTime1).TotalMinutes > 45)
                    {
                        if (speed !> 25 && speed > 0)
                        {
                            return Convert.ToInt32(roadLenght) * perRoadToken;
                        }
                    }
                    return 0;
            }
            return 0;
        }
    }
}
