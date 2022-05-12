namespace ContactList.Core.Dtos.Login
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
