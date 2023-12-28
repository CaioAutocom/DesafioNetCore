namespace DesafioNetCore.API;

public class AppSettings
{
    public string Secret { get; set; }
    public int ExpireTime { get; set; }
    public string Issuer { get; set; }
    public string LifeTime{ get; set; }
}
