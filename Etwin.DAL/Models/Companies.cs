using System.ComponentModel.DataAnnotations;

namespace EtwLogin.Models
{
    public class Companies
    {
        [Key]
        public int IdCompany { set; get; }
        public string CompanyName { set; get; }
        public string ConnectionString { set; get; }
    }
}
