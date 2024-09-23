using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cerberus.Domain.Models.Machine
{
    public class ComputerFile
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Json { get; set; }

        [Required]
        public string Type { get; set; }

        [ForeignKey(nameof(Computer))]
        public int ComputerID {  get; set; }

        public Computer Computer {  get; set; }



    }
}
