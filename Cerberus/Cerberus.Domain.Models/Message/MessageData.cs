using Cerberus.Domain.Models.Static;

namespace Cerberus.Domain.Models.Message
{
    public class MessageData
    {

        public int ID { get; set; }

        public string Data {  get; set; }

        public MessageType Type { get; set; }

    }
}
