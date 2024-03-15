using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class CadastroExecutivo
    {
        public static void CadastrarPresidente(List<Presidente> presidentes, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de presidentes:");
            string nomePresidente = NomePolitico();
            int idadePresidente = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            if (partido.numPresidente == 0)
            {
                presidentes.Add(new Presidente(nomePresidente, idadePresidente, partido));
                partido.setPresidente(new Presidente(nomePresidente, idadePresidente, partido));
                Console.WriteLine("\nPresidente cadastrado!");
            }
            else
            {
                Console.WriteLine("\nEsse partido ja possui um presidente!\n1 - Cadastrar em outro partido\n2 - Voltar ao menu");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                    CadastroExecutivo.CadastrarPresidente(presidentes, partidos);
                else
                    Menu.menu();
            }
        }
        public static void CadastrarGorvenador(List<Gorvenador> gorvenadores, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de gorvenadores:");
            string nomeGorvenador = NomePolitico();
            int idadeGorvenador = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            if (partido.numGorvenador == 0)
            {
                gorvenadores.Add(new Gorvenador(nomeGorvenador, idadeGorvenador, partido));
                partido.setGorvenador(new Gorvenador(nomeGorvenador, idadeGorvenador, partido));
                Console.WriteLine("\nGorvenador cadastrado!");
            }
            else
            {
                Console.WriteLine("\nEsse partido ja possui um gorvenador!\n1 - Cadastrar em outro partido\n2 - Voltar ao menu");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                    CadastroExecutivo.CadastrarGorvenador(gorvenadores, partidos);
                else
                    Menu.menu();
            }
        }
        public static void CadastrarPrefeito(List<Prefeito> prefeitos, List<Partido> partidos)
        {
            Console.WriteLine("------------------------------\nCadastro de prefeitos:");
            string nomePrefeito = NomePolitico();
            int idadePrefeito = IdadePolitico();
            Partido partido = PartidoPolitico(partidos);
            if (partido.numPrefeito == 0)
            {
                prefeitos.Add(new Prefeito(nomePrefeito, idadePrefeito, partido));
                partido.setPrefeito(new Prefeito(nomePrefeito, idadePrefeito, partido));
                Console.WriteLine("\nPrefeito cadastrado!");
            }
            else
            {
                Console.WriteLine("\nEsse partido ja possui um prefeito!\n1 - Cadastrar em outro partido\n2 - Voltar ao menu");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                    CadastroExecutivo.CadastrarPrefeito(prefeitos, partidos);
                else
                    Menu.menu();
            }
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
