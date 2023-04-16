using System.ComponentModel.DataAnnotations;

namespace EtwLogin.Models
{
    public class Operators
    {
        //public int IdOperator { get; set; }
        //public string NameSurname { get; set; }
        //public int IdCompany { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public bool RememberPassword { get; set; }
        //public bool Active { get; set; }
        //public string IPAddress { get; set; }



        public string OperatorCode { get; set; }
        public string BadgeCode { get; set; }
        public int IdOperatorRole { get; set; }
        public int IdDepartment { get; set; }
        public string IdOperatorState { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Ip { get; set; }
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdOperatorAccess { get; set; }
    }
}
