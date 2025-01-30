using System.Xml.Serialization;

namespace MyApp_Factory
{
    public class Cliente
    {
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }

    public class GerXML
    {
        public string GeraXML(Object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, obj);

            return sw.ToString();
        }
    }

    internal class Program_Adapter
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Jorge";
            cliente.Endereco = "São Paulo";
            cliente.DataNascimento = new DateTime(1998, 02, 27);

            GerXML clienteXML = new GerXML();
            Console.WriteLine(clienteXML.GeraXML(cliente));
        }
    }
}
