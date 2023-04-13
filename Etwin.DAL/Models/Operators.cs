namespace EtwLogin.Models
{
    public class Operators
    {
        public int IdOperator { get; set; }
        public string NameSurname { get; set; }
        public int IdCompany { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberPassword { get; set; }
        public bool Active { get; set; }
        public string IPAddress { get; set; }
    }
}
