using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace urna
{
    class Votos
    {
        public static void Votar(List<Partido> partidos, List<Presidente> presidentes, List<Prefeito> prefeitos, List<Gorvenador> gorvenadores, List<DepEstadual> deputadosEstaduais, List<DepFederal> deputadosFederais, List<Vereador> vereadores)
        {
            TotalVotos.vtsValidosPref = 0; TotalVotos.vtsValidosVer = 0; TotalVotos.vtsPres = 0; TotalVotos.vtsGov = 0; TotalVotos.vtsEstadual = 0; TotalVotos.VtsFed = 0;
            Console.Write("\nQuantos votos serão feitos? ");
            int populacao = int.Parse(Console.ReadLine());
            Console.WriteLine("\n1 - Votar em eleições municipais\n2 - Votar em eleições gerais\n3 - Voltar pro menu");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    EleicoesMunicipais.Eleicoes(partidos, prefeitos, vereadores, populacao);
                    break;
                case 2:
                    EleicoesGerais.Eleicoes(partidos, presidentes, gorvenadores, deputadosEstaduais, deputadosFederais, populacao);
                    break;
                default:
                    Menu.menu();
                    break;
            }

        }
    }
}
