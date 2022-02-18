namespace PlayerAPI
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Club { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime LastModified { get; set; }
    }
}
