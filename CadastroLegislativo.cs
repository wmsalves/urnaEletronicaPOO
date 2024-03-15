using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class CadastroLegislativo
    {
        public static void CadastrarDepFederal(List<DepFederal> depFederais, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de deputados federais:");
            string nomeDeputado = NomePolitico();
            int idadeDeputado = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            int legenda = Legenda(partido, 0);
            depFederais.Add(new DepFederal(nomeDeputado, idadeDeputado, partido, legenda));
            partido.setDepFederais(new DepFederal(nomeDeputado, idadeDeputado, partido, legenda));
            Console.WriteLine("\nDeputado federal cadastrado!");
        }
        public static void CadastrarDepEstadual(List<DepEstadual> depEstaduais, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de deputados estaduais:");
            string nomeDeputado = NomePolitico();
            int idadeDeputado = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            int legenda = Legenda(partido, 1);
            depEstaduais.Add(new DepEstadual(nomeDeputado, idadeDeputado, partido, legenda));
            partido.setDepEstaduais(new DepEstadual(nomeDeputado, idadeDeputado, partido, legenda));
            Console.WriteLine("\nDeputado estadual cadastrado!");
        }
        public static void CadastrarVereador(List<Vereador> vereadores, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de vereadores:");
            string nomeVereador = NomePolitico();
            int idadeVereador = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            int legenda = Legenda(partido, 0);
            vereadores.Add(new Vereador(nomeVereador, idadeVereador, partido, legenda));
            partido.setVereadores(new Vereador(nomeVereador, idadeVereador, partido, legenda));
            Console.WriteLine("\nVereador cadastrado!");
        }
        private static string NomePolitico()
        {
            Console.Write("Nome do politico: ");
            string nome = Console.ReadLine().ToUpper();
            return nome;
        }
        private static int IdadePolitico()
        {
            Console.Write("Idade do politico: ");
            int idade = int.Parse(Console.ReadLine());
            return idade;
        }
        private static Partido PartidoPolitico(List<Partido> partidos)
        {
            Console.Write("Sigla do partido do politico: ");
            string sigla = Console.ReadLine().ToUpper();
            foreach (Partido partido in partidos)
            {
                if (sigla.Equals(partido.getSigla()))
                {
                    return partido;
                }
            }
            Console.WriteLine("Partido não encontrado!\n1 - Tentar novamente\n2 - Criar um partido");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
                return PartidoPolitico(partidos);
            else
            {
                CadastroPartido.CadastrarPartido(partidos);
                return PartidoPolitico(partidos);
            }
        }
        private static int Legenda(Partido partido, int cargo)
        {
            if (cargo == 1)
                return InserirLegenda(partido, 5);
            else
                return InserirLegenda(partido, 4);
        }
        private static int InserirLegenda(Partido partido, int num)
        {
            int numTam = num - 2;
            int n = partido.getLegenda();
            Console.Write("Número do candidato (sem os dois primeiros números do partido): ");
            int m = int.Parse(Console.ReadLine());
            string a = n.ToString() + m;
            if (a.Length == num)
            {
                int b = int.Parse(a);
                return b;
            }
            else
            {
                Console.WriteLine("\nVocê deve digitar apenas " + numTam + " digitos!");
                return InserirLegenda(partido, num);
            }
        }
        private static Partido AutoPartidoPolitico(List<Partido> partidos, string sigla)
        {
            foreach (Partido partido in partidos)
            {
                if (sigla.Equals(partido.getSigla()))
                {
                    return partido;
                }
            }
            Console.WriteLine("Partido não encontrado!\n1 - Tentar novamente\n2 - Criar um partido");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
                return PartidoPolitico(partidos);
            else
            {
                CadastroPartido.CadastrarPartido(partidos);
                return PartidoPolitico(partidos);
            }
        }
    }
}
