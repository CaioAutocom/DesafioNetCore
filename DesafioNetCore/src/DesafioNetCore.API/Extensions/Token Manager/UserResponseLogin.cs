namespace DesafioNetCore.API.Extensions;

public class UserResponseLogin
{
    public string AccessToken { get; set; } = string.Empty;
    public double ExpiresIn { get; set; }
    public UserToken UserToken { get; set; }
}
