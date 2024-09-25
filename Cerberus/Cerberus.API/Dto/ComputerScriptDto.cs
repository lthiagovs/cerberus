using Cerberus.Domain.Models.Machine;

namespace Cerberus.API.Dto
{
    public class ComputerScriptDto
    {

        public string Name { get; set; }

        public bool Active {  get; set; }

        public Computer Computer {  get; set; }

    }

}
