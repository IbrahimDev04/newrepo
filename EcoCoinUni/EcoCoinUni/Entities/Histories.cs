using EcoCoinUni.Entities.Commons;

namespace EcoCoinUni.Entities;

public class Histories : BaseEntity
{
    public string From { get; set; }
    public string To { get; set; }
    public double RoadLenght { get; set; }
    public int Speed { get; set; }
    public double Time { get; set; }
    public int Token { get; set; }
    public bool Status { get; set; }

    public string UserId { get; set; }
    public AppUser User { get; set; }

    public int TransportId { get; set; }
    public TransportType Transport { get; set; }
}

