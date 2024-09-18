using Cerberus.Domain.Models.Person;
using Cerberus.Domain.Models.Static;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Domain.Models.Machine
{
    public class Computer
    {

        [Key]
        public int Id {  get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string MAC {  get; set; }

        [Required]
        public string IP {  get; set; }

        [Required]
        public OS OS { get; set; }

        [ForeignKey(nameof(Victim))]
        public int VictimID {  get; set; }

        public Victim Victim {  get; set; }

    }
}
