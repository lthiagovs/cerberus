using Cerberus.Domain.Models.Person;

namespace Cerberus.Domain.Models.Machine
{
    public class Computer
    {

        public int Id {  get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string MAC {  get; set; }

        public string IP {  get; set; }

        public OperatingSystem OS { get; set; }

        public int VictimID {  get; set; }

        public Victim Victim {  get; set; }

    }
}
