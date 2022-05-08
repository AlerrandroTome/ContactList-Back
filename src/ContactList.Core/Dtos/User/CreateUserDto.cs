namespace ContactList.Core.Dtos.User
{
    public class CreateUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public ICollection<Guid> Contacts { get; set; } = new List<Guid>();
    }
}
