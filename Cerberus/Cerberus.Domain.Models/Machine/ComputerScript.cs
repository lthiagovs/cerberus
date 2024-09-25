using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Domain.Models.Machine
{
    public class ComputerScript
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Active { get; set; }

        [ForeignKey(nameof(Computer))]
        public int ComputerId {  get; set; }

        public Computer Computer {  get; set; }

    }

}
