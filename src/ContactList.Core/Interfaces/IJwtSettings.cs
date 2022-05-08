namespace ContactList.Core.Interfaces
{
    public interface IJwtSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
