namespace fazyup.api.Feature.User
{
    public class UserOutput
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public UserOutput(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
