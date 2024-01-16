using DesafioNetCore.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;


namespace DesafioNetCore.Domain.Entities
{
    public class User : IdentityUser
    {
        public string ShortId { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty; 
        public string Document { get; set; } = string.Empty;

        public User()
        {
            ShortId = ShortIdExtension.ToBase64(Id);
        }
    }
}
