using EcoCoinUni.Entities.Commons;

namespace EcoCoinUni.Entities;

public class TransportType : BaseEntity
{
    public string Name { get; set; }
    public int TokenPerWay { get; set; }
    public ICollection<Histories> Histories { get; set; }
}

