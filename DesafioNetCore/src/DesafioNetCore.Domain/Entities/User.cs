using DesafioNetCore.Entities.Enums;
using DesafioNetCore.Domain.Entities.Common;

namespace DesafioNetCore.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public EAccessPriority AccessPriority { get; set; } = EAccessPriority.Administrator;
    }
}
