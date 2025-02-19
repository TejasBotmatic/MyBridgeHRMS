namespace MyBridgeHRMS.AuthModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ?RefreshToken { get; set; }
        public DateTime ?RefreshTokenExpire { get; set; }

        public int ?RoleId { get; set; }
        public Role ?Role { get; set; }

    }
}
