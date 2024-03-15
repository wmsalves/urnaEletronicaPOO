using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Cadastro
    {
        public static void CadastrosPartido(List<Partido> partidos)
        {
            for (int i = 0; i < 100; i++)
            {
                CadastroPartido.CadastrarPartido(partidos);
                Console.WriteLine("\nCadastrar outro partido?\n1 - SIM\n2 - NAO");
                int op = int.Parse(Console.ReadLine());
                if (op == 2)
                    i = 100;
            }
        }
        public static void CadastroPoliticosExecutivos(List<Partido> partidos, List<Presidente> presidentes, List<Prefeito> prefeitos, List<Gorvenador> gorvenadores)
        {
            Console.WriteLine("\nCADASTRO POLITICOS EXECUTIVOS\n1 - Cadastrar todos\n2 - Cadastrar apenas presidentes\n3 - Cadastrar apenas prefeitos\n4 - Cadastrar apenas governadores\nDigite qualquer tecla para cancelar");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR PRESIDENTE");
                        CadastroExecutivo.CadastrarPresidente(presidentes, partidos);
                        Console.WriteLine("\nCadastrar outro presidente?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR PREFEITO");
                        CadastroExecutivo.CadastrarPrefeito(prefeitos, partidos);
                        Console.WriteLine("\nCadastrar outro prefeito?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR GORVENADOR");
                        CadastroExecutivo.CadastrarGorvenador(gorvenadores, partidos);
                        Console.WriteLine("\nCadastrar outro gorvenador?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 2:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR PRESIDENTE");
                        CadastroExecutivo.CadastrarPresidente(presidentes, partidos);
                        Console.WriteLine("\nCadastrar outro presidente?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 3:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR PREFEITO");
                        CadastroExecutivo.CadastrarPrefeito(prefeitos, partidos);
                        Console.WriteLine("\nCadastrar outro prefeito?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 4:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("CADASTRAR GORVENADOR");
                        CadastroExecutivo.CadastrarGorvenador(gorvenadores, partidos);
                        Console.WriteLine("\nCadastrar outro gorvenador?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void CadastroPoliticosLegislativos(List<Partido> partidos, List<DepEstadual> deputadosEstaduais, List<DepFederal> deputadosFederais, List<Vereador> vereadores)
        {
            Console.WriteLine("\nCADASTRO POLITICOS LEGISLATIVOS\n1 - Cadastrar todos\n2 - Cadastrar apenas deputados estaduais\n3 - Cadastrar apenas deputados federais\n4 - Cadastrar apenas vereadores\nDigite qualquer tecla para cancelar");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("DEPUTADO ESTADUAL");
                        CadastroLegislativo.CadastrarDepEstadual(deputadosEstaduais, partidos);
                        Console.WriteLine("\nCadastrar outro deputado estadual?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("DEPUTADO FEDERAL");
                        CadastroLegislativo.CadastrarDepFederal(deputadosFederais, partidos);
                        Console.WriteLine("\nCadastrar outro deputado federal?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("VEREADOR");
                        CadastroLegislativo.CadastrarVereador(vereadores, partidos);
                        Console.WriteLine("\nCadastrar outro vereador?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 2:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("DEPUTADO ESTADUAL");
                        CadastroLegislativo.CadastrarDepEstadual(deputadosEstaduais, partidos);
                        Console.WriteLine("\nCadastrar outro deputado estadual?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 3:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("DEPUTADO FEDERAL");
                        CadastroLegislativo.CadastrarDepFederal(deputadosFederais, partidos);
                        Console.WriteLine("\nCadastrar outro deputado federal?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                case 4:
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("VEREADOR");
                        CadastroLegislativo.CadastrarVereador(vereadores, partidos);
                        Console.WriteLine("\nCadastrar outro vereador?\n1 - SIM\n2 - NAO");
                        int op = int.Parse(Console.ReadLine());
                        if (op == 2)
                            i = 100;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}


