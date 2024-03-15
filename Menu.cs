using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Menu
    {
        public static List<Partido> partidos = new List<Partido>();

        public static List<Presidente> presidentes = new List<Presidente>();
        public static List<Prefeito> prefeitos = new List<Prefeito>();
        public static List<Gorvenador> gorvenadores = new List<Gorvenador>();

        public static List<DepEstadual> deputadosEstaduais = new List<DepEstadual>();
        public static List<DepFederal> deputadosFederais = new List<DepFederal>();
        public static List<Vereador> vereadores = new List<Vereador>();
        public static void menu()
        {
            int op;
            bool flag = false;
            while (flag != true)
            {
                Console.WriteLine("\n*****MENU******\n1 - Cadastrar Partidos\n2 - Cadastrar Politicos Executivos" +
                    "\n3 - Cadastrar Politicos Legislativos\n4 - Votar (cadastrar partidos e politicos antes)\nDigite qualquer outra tecla para sair do programa");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Cadastro.CadastrosPartido(partidos);
                        break;
                    case 2:
                        Cadastro.CadastroPoliticosExecutivos(partidos, presidentes, prefeitos, gorvenadores);
                        break;
                    case 3:
                        Cadastro.CadastroPoliticosLegislativos(partidos, deputadosEstaduais, deputadosFederais, vereadores);
                        break;
                    case 4:
                        Votos.Votar(partidos, presidentes, prefeitos, gorvenadores, deputadosEstaduais, deputadosFederais, vereadores);
                        break;
                    default:
                        flag = true;
                        break;
                }
            }
        }
    }
}
