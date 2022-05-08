namespace ContactList.Core.Dtos.Contact
{
    public class UpdateContactDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WhatsappNumber { get; set; }
        public bool PhoneNumberIsAlreadyWhatsapp { get; set; } = false;
        public Guid UserId { get; set; }
    }
}
