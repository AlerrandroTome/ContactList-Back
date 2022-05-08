namespace ContactList.Core.Dtos.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public ICollection<Guid> Contacts { get; set; } = new List<Guid>();
    }
}
