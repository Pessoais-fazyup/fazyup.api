namespace fazyup.api.Shared.Configs
{
    public class JwtConfiguration
    {
        public string Secret { get; set; }
        public string Emitter { get; set; }
        public string ValidIn { get; set; }
        public int ExpirationHours { get; set; }

    }
}