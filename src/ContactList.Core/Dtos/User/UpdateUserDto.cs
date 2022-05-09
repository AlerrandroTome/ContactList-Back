namespace ContactList.Core.Dtos.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
