using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace urna
{
    class EleicoesGerais
    {
        public static void Eleicoes(List<Partido> partidos, List<Presidente> presidentes, List<Gorvenador> gorvenadores, List<DepEstadual> depEstaduais, List<DepFederal> depFederais, int populacao)
        {
            ImprimirGerais(partidos);
            foreach (Presidente a in presidentes)
                a.ZerarVotos();
            foreach (Gorvenador a in gorvenadores)
                a.ZerarVotos();
            foreach (DepEstadual a in depEstaduais)
                a.ZerarVotos();
            foreach (DepFederal a in depFederais)
                a.ZerarVotos();
            for (int i = 0; i < populacao; i++)
            {
                VotarPresidentes(partidos, presidentes);
                VotarGorvenadores(partidos, gorvenadores);
                VotarDepEstadual(partidos, depEstaduais);
                VotarDepFederal(partidos, depFederais);
            }
            Console.WriteLine("\nRESULTADO DAS ELEIÇÕES: \n");
            ResultadoPresidentes(presidentes, populacao);
            ResultadoGorvenadores(gorvenadores, populacao);
            ResultadoDepEstaduais(partidos, depEstaduais, populacao);
            ResultadoDepFederais(partidos, depFederais, populacao);
        }

        private static void VotarDepEstadual(List<Partido> partidos, List<DepEstadual> deputadosEstaduais)
        {
            Console.Write("\nSEU VOTO PARA DEP. ESTADUAL: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (DepEstadual deputado in deputadosEstaduais)
            {
                if (legenda == deputado.getLegenda())
                {
                    deputado.Votos(); //Adiciona 1 voto pro vereador
                    TotalVotos.vtsValidosVer++; //Adiciona 1 voto valido geral
                }
            }
        }
        private static void ResultadoDepEstaduais(List<Partido> partidos, List<DepEstadual> deputadosEstaduais, int populacao)
        {
            Console.WriteLine("\nDEP. ESTADUAIS");
            int numEleitos = 5;
            QuickSortDepE(0, deputadosEstaduais.Count() - 1, deputadosEstaduais);
            Console.WriteLine("DEP. ESTADUAIS: ");
            for (int i = 0; i < numEleitos; i++)
            {
                int pos = i + 1;
                Console.WriteLine(pos + "° lugar: " + deputadosEstaduais[i].Nome() + " (" + deputadosEstaduais[i].getSigla() + ") || Votos: " + deputadosEstaduais[i].getVotos());
            }
        }

        private static void VotarDepFederal(List<Partido> partidos, List<DepFederal> depFederais)
        {
            Console.Write("\nSEU VOTO PARA DEP. FEDERAL: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (DepFederal deputado in depFederais)
            {
                if (legenda == deputado.getLegenda())
                {
                    deputado.Votos(); //Adiciona 1 voto pro vereador
                    TotalVotos.vtsValidosVer++; //Adiciona 1 voto valido geral
                }
            }
        }
        private static void ResultadoDepFederais(List<Partido> partidos, List<DepFederal> depFederais, int populacao)
        {
            Console.WriteLine("\nDEP. FEDERAIS");
            int numEleitos = 5;
            QuickSortDepF(0, depFederais.Count() - 1, depFederais);
            Console.WriteLine("DEP. FEDERAIS: ");
            for (int i = 0; i < numEleitos; i++)
            {
                int pos = i + 1;
                Console.WriteLine(pos + "° lugar: " + depFederais[i].Nome() + " (" + depFederais[i].getSigla() + ") || Votos: " + depFederais[i].getVotos());
            }
        }

        private static void ResultadoGorvenadores(List<Gorvenador> gorvenadores, int populacao)
        {
            Console.WriteLine("\n----------------------------------\nGORVENADORES\nVotos validos: " + TotalVotos.vtsGov + " || Votos invalidos: " + TotalVotos.InvalidosGov(populacao));
            QuickSortGor(0, gorvenadores.Count() - 1, gorvenadores);
            double pct = 0, pctMax = 0;
            foreach (Gorvenador gorvenador in gorvenadores)
            {
                pct = (double)(gorvenador.getVotos() * 100) / TotalVotos.vtsGov;
                Console.WriteLine(gorvenador.Nome() + "(" + gorvenador.siglaPartido() + ")" + " || Votos: " + gorvenador.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                if (pct > pctMax)
                    pctMax = pct;
            }

            if (pctMax < 51)
            {
                TotalVotos.vtsValidosPref = 0;
                Console.WriteLine("\nSEGUNDO TURNO: ");
                List<Gorvenador> segundoTurno = new List<Gorvenador>();
                for (int i = 0; i < 2; i++)
                {
                    gorvenadores[i].ZerarVotos();
                    segundoTurno.Add(gorvenadores[i]);
                }
                for (int i = 0; i < populacao; i++)
                    SegundoTurnoGorvenadores(segundoTurno);
                foreach (Gorvenador gorvenador in segundoTurno)
                {
                    pct = (double)(gorvenador.getVotos() * 100) / TotalVotos.getVtsValidosPref();
                    if (pct > 50)
                        Console.WriteLine("1° lugar: " + gorvenador.Nome() + "(" + gorvenador.siglaPartido() + ")" + " || Votos: " + gorvenador.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    else if (pct < 50)
                        Console.WriteLine("2° lugar: " + gorvenador.Nome() + "(" + gorvenador.siglaPartido() + ")" + " || Votos: " + gorvenador.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    else
                    {
                        if (segundoTurno[0].Idade() > segundoTurno[1].Idade())
                            Console.WriteLine("1° lugar: " + segundoTurno[0].Nome() + "(" + segundoTurno[0].siglaPartido() + ")" + " || Votos: " + segundoTurno[0].getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                        else
                            Console.WriteLine("1° lugar: " + segundoTurno[1].Nome() + "(" + segundoTurno[1].siglaPartido() + ")" + " || Votos: " + segundoTurno[1].getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    }
                }
            }
        }
        private static void SegundoTurnoGorvenadores(List<Gorvenador> segundoTurno)
        {
            Console.Write("\nSEU VOTO PARA GORVENADOR (segundo turno): ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Gorvenador gorvenador in segundoTurno)
            {
                if (legenda == gorvenador.numeroPartido())
                {
                    gorvenador.Votos(); //Adiciona 1 voto pro prefeito
                    TotalVotos.VtsValidosPref(); //Adiciona 1 voto valido geral
                }
            }
        }
        private static void VotarGorvenadores(List<Partido> partidos, List<Gorvenador> gorvenadores)
        {
            Console.Write("\nSEU VOTO PARA GORVENADOR: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Gorvenador gorvenador in gorvenadores)
            {
                if (legenda == gorvenador.numeroPartido())
                {
                    gorvenador.Votos(); //Adiciona 1 voto pro gorvenador
                    TotalVotos.vtsGov++; //Adiciona 1 voto valido geral
                }
            }
        }

        private static void ResultadoPresidentes(List<Presidente> presidentes, int populacao)
        {
            Console.WriteLine("\n----------------------------------\nPRESIDENTES\nVotos validos: " + TotalVotos.vtsPres + " || Votos invalidos: " + TotalVotos.InvalidosPres(populacao));
            QuickSortPres(0, presidentes.Count() - 1, presidentes);
            double pct = 0, pctMax = 0;
            foreach (Presidente presidente in presidentes)
            {
                pct = (double)(presidente.getVotos() * 100) / TotalVotos.vtsPres;
                Console.WriteLine(presidente.Nome() + "(" + presidente.siglaPartido() + ")" + " || Votos: " + presidente.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                if (pct > pctMax)
                    pctMax = pct;
            }

            if (pctMax < 51)
            {
                TotalVotos.vtsValidosPref = 0;
                Console.WriteLine("\nSEGUNDO TURNO: ");
                List<Presidente> segundoTurno = new List<Presidente>();
                for (int i = 0; i < 2; i++)
                {
                    presidentes[i].ZerarVotos();
                    segundoTurno.Add(presidentes[i]);
                }
                for (int i = 0; i < populacao; i++)
                    SegundoTurnoPresidentes(segundoTurno);
                foreach (Presidente presidente in segundoTurno)
                {
                    pct = (double)(presidente.getVotos() * 100) / TotalVotos.getVtsValidosPref();
                    if (pct > 50)
                        Console.WriteLine("1° lugar: " + presidente.Nome() + "(" + presidente.siglaPartido() + ")" + " || Votos: " + presidente.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    else if (pct < 50)
                        Console.WriteLine("2° lugar: " + presidente.Nome() + "(" + presidente.siglaPartido() + ")" + " || Votos: " + presidente.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    else
                    {
                        if (segundoTurno[0].Idade() > segundoTurno[1].Idade())
                            Console.WriteLine("1° lugar: " + segundoTurno[0].Nome() + "(" + segundoTurno[0].siglaPartido() + ")" + " || Votos: " + segundoTurno[0].getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                        else
                            Console.WriteLine("1° lugar: " + segundoTurno[1].Nome() + "(" + segundoTurno[1].siglaPartido() + ")" + " || Votos: " + segundoTurno[1].getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    }
                }
            }
        }
        private static void SegundoTurnoPresidentes(List<Presidente> segundoTurno)
        {
            Console.Write("\nSEU VOTO PARA PRESIDENTE (segundo turno): ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Presidente presidente in segundoTurno)
            {
                if (legenda == presidente.numeroPartido())
                {
                    presidente.Votos(); //Adiciona 1 voto pro prefeito
                    TotalVotos.VtsValidosPref(); //Adiciona 1 voto valido geral
                }
            }
        }
        private static void VotarPresidentes(List<Partido> partidos, List<Presidente> presidentes)
        {
            Console.Write("\nSEU VOTO PARA PRESIDENTE: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Presidente presidente in presidentes)
            {
                if (legenda == presidente.numeroPartido())
                {
                    presidente.Votos(); //Adiciona 1 voto pro prefeito
                    TotalVotos.vtsPres++; //Adiciona 1 voto valido geral
                }
            }
        }

        static void QuickSortDepE(int esq, int dir, List<DepEstadual> depEstaduais)
        {
            int i = esq, j = dir;
            int pivo = depEstaduais[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (depEstaduais[i].getVotos() > pivo) i++;
                while (depEstaduais[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    DepEstadual temp = depEstaduais[j];
                    depEstaduais[j] = depEstaduais[i];
                    depEstaduais[i] = (DepEstadual)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSortDepE(esq, j, depEstaduais);
            if (i < dir) QuickSortDepE(i, dir, depEstaduais);
        }
        static void QuickSortDepF(int esq, int dir, List<DepFederal> depFederais)
        {
            int i = esq, j = dir;
            int pivo = depFederais[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (depFederais[i].getVotos() > pivo) i++;
                while (depFederais[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    DepFederal temp = depFederais[j];
                    depFederais[j] = depFederais[i];
                    depFederais[i] = (DepFederal)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSortDepF(esq, j, depFederais);
            if (i < dir) QuickSortDepF(i, dir, depFederais);
        }
        static void QuickSortGor(int esq, int dir, List<Gorvenador> gorvenadores)
        {
            int i = esq, j = dir;
            int pivo = gorvenadores[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (gorvenadores[i].getVotos() > pivo) i++;
                while (gorvenadores[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    Gorvenador temp = gorvenadores[j];
                    gorvenadores[j] = gorvenadores[i];
                    gorvenadores[i] = (Gorvenador)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSortGor(esq, j, gorvenadores);
            if (i < dir) QuickSortGor(i, dir, gorvenadores);
        }
        static void QuickSortPres(int esq, int dir, List<Presidente> presidentes)
        {
            int i = esq, j = dir;
            int pivo = presidentes[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (presidentes[i].getVotos() > pivo) i++;
                while (presidentes[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    Presidente temp = presidentes[j];
                    presidentes[j] = presidentes[i];
                    presidentes[i] = (Presidente)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSortPres(esq, j, presidentes);
            if (i < dir) QuickSortPres(i, dir, presidentes);
        }
        private static void ImprimirGerais(List<Partido> partidos)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("LISTA DE PRESIDENTES: ");
            foreach (Partido partido in partidos)
            {
                Console.WriteLine(partido.getPresidente());
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("\nLISTA DE GOVERNADORES:");
            foreach (Partido partido in partidos)
            {
                Console.WriteLine(partido.getGorvenador());
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("\nLISTA DE DEPUTADOS ESTADUAIS:");
            foreach (Partido partido in partidos)
            {
                partido.getDepEstaduais();
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("\nLISTA DE DEPUTADOS FEDERAIS:");
            foreach (Partido partido in partidos)
            {
                partido.getDepFederais();
            }
            Console.WriteLine("-----------------------");
        }
    }
}
