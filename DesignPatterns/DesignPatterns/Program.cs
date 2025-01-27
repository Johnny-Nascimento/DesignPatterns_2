using Microsoft.Data.SqlClient;
using System.Data;

namespace MyApp_Factory
{
    internal class Program_Visitor
    {
        public interface IExpressao
        {
            public int Avalia();
            public void Aceita(ImpressoraVisitor impressora);
        }

        public class Numero : IExpressao
        {
            public int Valor { get; private set; }

            public Numero(int numero)
            {
                Valor = numero;
            }

            public int Avalia()
            {
                return Valor;
            }

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeNumero(this);
            }
        }

        public class Soma : IExpressao
        {
            public IExpressao Esquerda{get; private set;}
            public IExpressao Direita { get; private set; }

            public Soma(IExpressao esquerda, IExpressao direita)
            {
                Esquerda = esquerda;
                Direita = direita;
            }

            public int Avalia()
            {
                return Esquerda.Avalia() + Direita.Avalia();
            }

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeSoma(this);
            }
        }

        public class Subtracao : IExpressao
        {
            public IExpressao Esquerda { get; private set; }
            public IExpressao Direita { get; private set; }

            public Subtracao(IExpressao esquerda, IExpressao direita)
            {
                Esquerda = esquerda;
                Direita = direita;
            }

            public int Avalia()
            {
                return Esquerda.Avalia() - Direita.Avalia();
            }

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeSubtracao(this);
            }
        }

        public class Multiplicacao : IExpressao
        {
            public IExpressao Esquerda { get; private set; }
            public IExpressao Direita { get; private set; }

            public Multiplicacao(IExpressao esquerda, IExpressao direita)
            {
                Esquerda = esquerda;
                Direita = direita;
            }

            public int Avalia()
            {
                return Esquerda.Avalia() * Direita.Avalia();
            }

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeMultiplicacao(this);
            }
        }

        public class Divisao : IExpressao
        {
            public IExpressao Esquerda { get; private set; }
            public IExpressao Direita { get; private set; }

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

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeDivisao(this);
            }
        }

        public class RaizQuadrada : IExpressao
        {
            public IExpressao Numero { get; private set; }

            public RaizQuadrada(IExpressao numero)
            {
                Numero = numero;
            }

            public int Avalia()
            {
                return (int)Math.Sqrt(Numero.Avalia());
            }

            public void Aceita(ImpressoraVisitor impressora)
            {
                impressora.ImprimeRaizQuadrada(this);
            }
        }

        public interface IVisitor
        {
            public void ImprimeSoma(Soma soma);
            public void ImprimeSubtracao(Subtracao subtracao);
            public void ImprimeDivisao(Divisao divisao);
            public void ImprimeMultiplicacao(Multiplicacao multiplicacao);
            public void ImprimeRaizQuadrada(RaizQuadrada raizQuadrada);
            public void ImprimeNumero(Numero numero);
        }

        public class ImpressoraVisitor : IVisitor
        {
            public void ImprimeSoma(Soma soma)
            {
                Console.Write("(");
                soma.Esquerda.Aceita(this);
                Console.Write("+");
                soma.Direita.Aceita(this);
                Console.Write(")");
            }

            public void ImprimeSubtracao(Subtracao subtracao)
            {
                Console.Write("(");
                subtracao.Esquerda.Aceita(this);
                Console.Write("-");
                subtracao.Direita.Aceita(this);
                Console.Write(")");
            }

            public void ImprimeDivisao(Divisao divisao)
            {
                Console.Write("(");
                divisao.Esquerda.Aceita(this);
                Console.Write("/");
                divisao.Direita.Aceita(this);
                Console.Write(")");
            }

            public void ImprimeMultiplicacao(Multiplicacao multiplicacao)
            {
                Console.Write("(");
                multiplicacao.Esquerda.Aceita(this);
                Console.Write("*");
                multiplicacao.Direita.Aceita(this);
                Console.Write(")");
            }

            public void ImprimeRaizQuadrada(RaizQuadrada raizQuadrada)
            {
                Console.Write("√");
                raizQuadrada.Numero.Aceita(this);
            }


            public void ImprimeNumero(Numero numero)
            {
                Console.Write(numero.Valor);
            }
        }

        internal class Program_Interpreter
        {
            static void Main(string[] args)
            {
                IExpressao esquerda = new Soma(new Numero(10), new Numero(15));
                IExpressao direita = new Subtracao(new Numero(40), new Numero(15));

                IExpressao soma = new RaizQuadrada(direita);

                Console.WriteLine(soma.Avalia());

                ImpressoraVisitor impressora = new ImpressoraVisitor();

                soma.Aceita(impressora);
            }
        }
    }
}