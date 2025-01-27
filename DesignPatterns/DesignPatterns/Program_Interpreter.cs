using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp_Interpreter
{
    public interface IExpressao
    {
        public int Avalia();
    }

    public class Numero : IExpressao
    {
        private int Num;
        public Numero(int numero) 
        {
            Num = numero;
        }

        public int Avalia()
        {
            return Num;
        }
    }

    public class Soma : IExpressao
    {
        private IExpressao Esquerda;
        private IExpressao Direita;

        public Soma(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            return Esquerda.Avalia() + Direita.Avalia();
        }
    }

    public class Subtracao : IExpressao
    {
        private IExpressao Esquerda;
        private IExpressao Direita;

        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            return Esquerda.Avalia() - Direita.Avalia();
        }
    }

    public class Multiplicacao : IExpressao
    {
        private IExpressao Esquerda;
        private IExpressao Direita;

        public Multiplicacao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            return Esquerda.Avalia() * Direita.Avalia();
        }
    }

    public class Divisao : IExpressao
    {
        private IExpressao Esquerda;
        private IExpressao Direita;

        public Divisao(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            int direita = Direita.Avalia();

            if (direita == 0)
                throw new Exception("Valor da direita não pode ser zero");

            return Esquerda.Avalia() / Direita.Avalia();
        }
    }

    public class RaizQuadrada : IExpressao
    {
        private IExpressao Numero;

        public RaizQuadrada(IExpressao numero)
        {
            Numero = numero;
        }

        public int Avalia()
        {
            return (int)Math.Sqrt(Numero.Avalia());
        }
    }

    internal class Program_Interpreter
    {
        static void Main_4(string[] args)
        {
            IExpressao esquerda = new Soma(new Numero(10), new Numero(15));
            IExpressao direita = new Subtracao(new Numero(20), new Numero(15));

            IExpressao resultado = new RaizQuadrada(new Numero(25));

            Console.WriteLine(resultado.Avalia());

            // Expression soma = Expression.Add(Expression.Constant(100), Expression.Constant(50));
            // Func<int> funcao = Expression.Lambda<Func<int>>(soma).Compile();
            // Console.WriteLine(funcao());
        }
    }
}