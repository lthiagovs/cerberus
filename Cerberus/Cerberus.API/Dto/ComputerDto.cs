using Cerberus.Domain.Models.Person;
using Cerberus.Domain.Models.Static;

namespace Cerberus.API.Dto
{
    public class ComputerDto
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string MAC {  get; set; }

        public string IP {  get; set; }

        public OS OS {  get; set; }

        public Victim Victim {  get; set; }

    }

}
