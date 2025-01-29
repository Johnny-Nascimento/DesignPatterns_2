
using static MyApp_Bridges.Program;

namespace MyApp_Bridges
{
    internal class Program
    {
        public interface IEnviador
        {
            void Envia(IMensagem mensagem);
        }

        public class EnviadorEmail : IEnviador
        {
            public void Envia(IMensagem mensagem)
            {
                Console.WriteLine("Enviando mensagem por email...");
                Console.WriteLine(mensagem.Formata());   
            }
        }

        public class EnviadorSMS : IEnviador
        {
            public void Envia(IMensagem mensagem)
            {
                Console.WriteLine("Enviando mensagem por SMS...");
                Console.WriteLine(mensagem.Formata());
            }
        }

        public interface IMensagem
        {
            void Envia(IEnviador enviador);
            string Formata();
        }

        public class MensagemPorEmail : IMensagem
        {
            private string nome;

            public MensagemPorEmail(string nome)
            {
                this.nome = nome;
            }

            public void Envia(IEnviador enviador)
            {
                enviador.Envia(this);
            }

            public string Formata()
            {
                return string.Format("Mensagem para o usuário {0}", nome);
            }
        }

        public class MensagemPorSMS : IMensagem
        {
            private string nome;

            public MensagemPorSMS(string nome)
            {
                this.nome = nome;
            }

            public void Envia(IEnviador enviador)
            {
                enviador.Envia(this);
            }

            public string Formata()
            {
                return string.Format("Mensagem para o usuário {0}", nome);
            }
        }

        static void Main(string[] args)
        {
            MensagemPorEmail mensagemEmail = new MensagemPorEmail("Jorge");
            mensagemEmail.Envia(new EnviadorEmail());

            MensagemPorSMS mensagemSMS = new MensagemPorSMS("Mario");
            mensagemSMS.Envia(new EnviadorSMS());
        }
    }
}