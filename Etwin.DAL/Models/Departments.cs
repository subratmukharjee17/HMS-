using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Etwin.DAL.Models
{
    public class Departments
    {
        [Key]
        public int IdDepartment { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationeDate { get; set; }
    }
}
