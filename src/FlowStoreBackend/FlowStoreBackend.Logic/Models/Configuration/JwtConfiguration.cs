namespace FlowStoreBackend.Logic.Models.Configuration
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int LifeTime { get; set; }
        public string SecretKey { get; set; } = default!;
    }
}
