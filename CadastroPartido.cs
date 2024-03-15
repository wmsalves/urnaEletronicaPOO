using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class CadastroPartido
    {
        public static void CadastrarPartido(List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de partidos:");
            partidos.Add(new Partido(NomePartido(partidos), SiglaPartido(partidos), CodigoPartido(partidos)));
            Console.WriteLine("\nPartido cadastrado!");
        }
        private static int CodigoPartido(List<Partido> partidos)
        {
            Console.Write("Legenda(número) do partido: ");
            int num = int.Parse(Console.ReadLine());
            foreach (Partido partido in partidos)
            {
                if (num == partido.getLegenda())
                {
                    Console.WriteLine("Número de legenda ja cadastrado!");
                    return CodigoPartido(partidos);
                }
            }
            return num;
        }
        private static string SiglaPartido(List<Partido> partidos)
        {
            Console.Write("Sigla do partido: ");
            string sigla = Console.ReadLine().ToUpper();
            foreach (Partido partido in partidos)
            {
                if (sigla.Equals(partido.getSigla()))
                {
                    Console.WriteLine("Sigla de legenda ja cadastrado!");
                    return SiglaPartido(partidos);
                }
            }
            return sigla;
        }
        private static string NomePartido(List<Partido> partidos)
        {
            Console.Write("Nome do partido: ");
            string nome = Console.ReadLine().ToUpper();
            foreach (Partido partido in partidos)
            {
                if (nome.Equals(partido.getSigla()))
                {
                    Console.WriteLine("Nome ja cadastrado!");
                    return NomePartido(partidos);
                }
            }
            return nome;
        }
    }
}
