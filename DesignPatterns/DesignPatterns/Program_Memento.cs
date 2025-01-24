using Microsoft.Data.SqlClient;
using System.Data;

namespace MyApp_Memento
{
    public enum TipoContrato
    {
        Novo,
        EmAndamento,
        Acertado,
        Concluido
    }

    public class Estado
    {
        public Contrato Contrato { get; private set; }

        public Estado(Contrato contrato)
        {
            Contrato = contrato;
        }
    }

    public class Historico
    {
        private List<Estado> Historicos = new List<Estado>();

        public void Adiciona(Estado estado)
        {
            Historicos.Add(estado);
        }

        public Estado Pega(int index)
        {
            return Historicos[index];
        }
    }

    public class Contrato
    {
        public DateTime Data { get; private set; }
        public string Cliente{ get; private set; }
        public TipoContrato Tipo{ get; private set; }

        public Contrato(DateTime data, string cliente, TipoContrato tipo)
        {
            Data = data;
            Cliente = cliente;
            Tipo = tipo;
        }

        public void Avanca()
        {
            switch (Tipo)
            {
                case TipoContrato.Novo:
                    Tipo = TipoContrato.EmAndamento;
                break;

                case TipoContrato.EmAndamento:
                    Tipo = TipoContrato.Acertado;
                break;

                case TipoContrato.Acertado:
                    Tipo = TipoContrato.Concluido;
                break;
            }
        }

        public Estado SalvaEstado()
        {
            return new Estado(new Contrato(Data, Cliente, Tipo));
        }
    }

    internal class Program_Memento
    {
        static void Main_3(string[] args)
        {
            Historico historico = new Historico();

            Contrato contrato = new Contrato(DateTime.Now, "Teste", TipoContrato.Novo);

            historico.Adiciona(contrato.SalvaEstado());
            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.WriteLine(historico.Pega(0).Contrato.Tipo);
            Console.WriteLine(historico.Pega(1).Contrato.Tipo);
        }
    }
}
