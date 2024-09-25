using System.ComponentModel.DataAnnotations;

namespace Cerberus.Domain.Models.Person
{
    public class Victim
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
