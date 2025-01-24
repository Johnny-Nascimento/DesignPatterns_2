using Microsoft.Data.SqlClient;
using System.Data;

namespace MyApp_Flyweight
{
    class NotasMusicais
    {
        private static IDictionary<string, INota> notas = new Dictionary<string, INota>()
        {
            { "do", new Do() },
            { "re", new Re() },
            { "mi", new Mi() },
            { "fa", new Fa() },
            { "sol", new Sol() },
            { "la", new La() },
            { "si", new Si() }
        };

        public INota Get(string nota)
        {
            return notas[nota];
        }
    }

    public interface INota
    {
        public int Frequencia {get;}
    }

    internal class Do : INota
    {
        public int Frequencia { get { return 262; } }
    }

    internal class Re : INota
    {
        public int Frequencia { get { return 294; } }
    }

    internal class Mi : INota
    {
        public int Frequencia { get { return 330; } }
    }

    internal class Fa : INota
    {
        public int Frequencia { get { return 349; } }
    }

    internal class Sol : INota
    {
        public int Frequencia { get { return 392; } }
    }

    internal class La : INota
    {
        public int Frequencia { get { return 440; } }
    }

    internal class Si : INota
    {
        public int Frequencia { get { return 490; } }
    }

    public class TocadorDeMusica
    {
        public void Toca(List<INota> musica)
        {
            foreach (INota nota in musica)
            {
                Console.Beep(nota.Frequencia, 300);
            }

        }
    }

    internal class Program_Flyweight
    {
        static void Main(string[] args)
        {
            NotasMusicais notasMusicais = new NotasMusicais();

            List<INota> musica = new List<INota>
            {
                notasMusicais.Get("do"),
                notasMusicais.Get("re"),
                notasMusicais.Get("mi"),
                notasMusicais.Get("fa"),
                notasMusicais.Get("fa"),
                notasMusicais.Get("fa")
            };

            TocadorDeMusica tocadorDeMusica = new TocadorDeMusica();
            tocadorDeMusica.Toca(musica);
        }
    }
}