
namespace MyApp_Singleton
{
    internal class Program
    {
        public class ServicoFacade
        {

        }

        public class ServicoSingleton
        {
            private static ServicoFacade Servico = new ServicoFacade();

            public ServicoFacade Instancia
            {
                get
                {
                    return Servico;
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}