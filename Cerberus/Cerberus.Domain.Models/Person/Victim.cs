using Cerberus.Domain.Models.Static;
using System.ComponentModel.DataAnnotations;

namespace Cerberus.Domain.Models.Person
{
    public class Victim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IP {  get; set; }

        [Required]
        public string Name { get; set; }

        public OS OS { get; set; }

    }
}
