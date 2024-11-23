using EcoCoinUni.Contexts;
using EcoCoinUni.Dtos.PaymentDtos;
using EcoCoinUni.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoCoinUni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {

        public AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Take/{userId}")]
        public async Task<IActionResult> TakeMoney(int CardNumber, int mounth, int year, int cvv, string FullName, string userId, int tokenCount)
        {
            var data = new ToCardInfo
            {
                CardNumber = 4324324,
                Date = DateTime.Now,
                FullName = "dsad",
                UserId = userId,
                TokenCount = tokenCount,
                TokenPrice = tokenCount / 100 * 2
            };

            await _context.toCards.AddAsync(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{UserId}")]
        public async Task<IActionResult> GetPaymentHistory(string UserId) 
        {
            
            var data = await _context.toCards.Where(x =>  x.UserId == UserId)
                .Select(x => new GetHistoryDto
                {
                    fullName = x.FullName,
                    cardNumber = x.CardNumber,
                    date = x.Date,
                    tokenCount = x.TokenCount,
                    tokenPrice = x.TokenPrice
                }).ToListAsync();

            return Ok(data);
        }

    }
}
