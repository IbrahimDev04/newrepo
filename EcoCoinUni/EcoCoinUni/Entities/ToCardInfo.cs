using EcoCoinUni.Entities.Commons;

namespace EcoCoinUni.Entities;

public class ToCardInfo : BaseEntity
{
    public int CardNumber { get; set; }
    public DateTime Date { get; set; }
    public string FullName { get; set; }
    public int TokenCount { get; set; }
    public double TokenPrice { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
}

