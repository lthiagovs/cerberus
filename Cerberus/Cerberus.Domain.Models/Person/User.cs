namespace Cerberus.Domain.Models.Person
{
    public class User
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password {  get; set; }

        public byte[]? ProfilePhoto {  get; set; }

    }
}
