using Cerberus.Domain.Models.Machine;

namespace Cerberus.API.Dto
{
    public class ComputerFileDto
    {

        public string Json { get; set; }

        public string Type {  get; set; }

        public Computer Computer {  get; set; }

    }

}
