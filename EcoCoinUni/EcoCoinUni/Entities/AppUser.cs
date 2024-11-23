using Microsoft.AspNetCore.Identity;

namespace EcoCoinUni.Entities;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int AllToken { get; set; }
    public ICollection<ToCardInfo> ToCards { get; set; }
    public ICollection<Histories> Histories { get; set; }

}
