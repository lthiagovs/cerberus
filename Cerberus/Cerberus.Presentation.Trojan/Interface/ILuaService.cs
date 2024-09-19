namespace Cerberus.Presentation.Trojan.Interface
{
    public interface ILuaService
    {

        public string Name { get; set; }
        
        public bool Start();

        public bool Get();

        public bool Stop();

    }

}
