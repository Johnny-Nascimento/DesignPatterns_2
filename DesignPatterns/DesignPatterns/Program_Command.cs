
using System.Windows.Input;
using static MyApp_Command.Program_Command;

namespace MyApp_Command
{
    internal class Program_Command
    {
        public enum Status
        {
            Novo,
            Processado,
            Pago,
            ItemSeparado,
            Entregue
        }

        public class Pedido
        {
            public string Cliente { get; private set; }
            public double Valor { get; private set; }
            public DateTime DataFinalizacao { get; private set; }
            public Status  Status { get; private set; }

            public Pedido(string cliente, double valor)
            {
                Cliente = cliente;
                Valor = valor;

                Status = Status.Novo;
            }

            public void Paga()
            {
                Status = Status.Pago;
            }

            public void Finaliza()
            {
                Status = Status.Entregue;
                DataFinalizacao = DateTime.Now;
            }
        }

        public interface IComando
        {
            void Executa();
        }

        public class PagaPedido : IComando
        {
            public Pedido pedido;

            public PagaPedido(Pedido pedido)
            {
                this.pedido = pedido;
            }

            public void Executa()
            {
                this.pedido.Paga();
            }
        }

        public class FinalizaPedido : IComando
        {
            private Pedido pedido;

            public FinalizaPedido(Pedido pedido)
            {
                this.pedido = pedido;
            }

            public void Executa()
            {
                this.pedido.Finaliza();
            }
        }

        public class FilaDeTrabalho
        {
            private IList<IComando> Comandos = new List<IComando>();

            public void Adiciona(IComando comando)
            {
                this.Comandos.Add(comando);
            }

            public void Processa()
            {
                foreach (var comando in Comandos)
                {
                    comando.Executa();
                }
            }
        }

        static void Main_7(string[] args)
        {
            Pedido pedido = new Pedido("Jorge", 10.00);

            FilaDeTrabalho fila = new FilaDeTrabalho();

            fila.Adiciona(new PagaPedido(pedido));

            Console.WriteLine(pedido.Status);
            Console.WriteLine(pedido.DataFinalizacao);

            fila.Adiciona(new FinalizaPedido(pedido));

            fila.Processa();

            Console.WriteLine(pedido.Status);
            Console.WriteLine(pedido.DataFinalizacao);
        }
    }
}