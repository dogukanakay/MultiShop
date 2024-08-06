namespace MultiShop.IdentityServer.Dtos
{
    public class ResultUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
