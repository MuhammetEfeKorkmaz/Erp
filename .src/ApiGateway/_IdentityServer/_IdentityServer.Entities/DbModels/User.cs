namespace _IdentityServer.Entities.DbModels
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        public string Password { get; set; }


    }
}
