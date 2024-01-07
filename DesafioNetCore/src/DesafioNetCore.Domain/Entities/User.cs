using DesafioNetCore.Entities.Enums;
using Microsoft.AspNetCore.Identity;


namespace DesafioNetCore.Domain.Entities
{
    public class User : IdentityUser
    {
        public string ShortId { get; } = Guid.NewGuid().ToString("N")[..10];
        public string Name { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty; 
        public string Document { get; set; } = string.Empty;
    }
}
