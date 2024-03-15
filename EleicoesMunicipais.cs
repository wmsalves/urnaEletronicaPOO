using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace urna
{
    class EleicoesMunicipais
    {
        public static void Eleicoes(List<Partido> partidos, List<Prefeito> prefeitos, List<Vereador> vereadores, int populacao)
        {
            foreach (Prefeito prefeito in prefeitos)
                prefeito.ZerarVotos();
            foreach (Vereador vereador in vereadores)
                vereador.ZeraVotos();

            ImprimirMunicipais(partidos);
            for (int i = 0; i < populacao; i++)
            {
                VotarPrefeitos(prefeitos);
                VotarVereadores(partidos, vereadores);
            }
            Console.WriteLine("\nRESULTADO DAS ELEIÇÕES: \n");
            ResultadoPrefeitos(prefeitos, populacao);
            ResultadoVereadores(partidos, vereadores, populacao);
        }
        private static void ResultadoVereadores(List<Partido> partidos, List<Vereador> vereadores, int populacao)
        {
            Console.WriteLine("\nVEREADORES\nVotos validos: " + TotalVotos.vtsValidosVer + " || Votos invalidos: " + TotalVotos.getVtsInvalidosVer(populacao));
            int numEleitos = 5;
            QuickSortVer(0, vereadores.Count() - 1, vereadores);
            Console.WriteLine("VEREADORES ELEITOS: ");
            for (int i = 0; i < numEleitos; i++)
            {
                int pos = i + 1;
                Console.WriteLine(pos + "° lugar: " + vereadores[i].Nome() + " (" + vereadores[i].getSigla() + ") || Votos: " + vereadores[i].getVotos());
            }
        }
        private static void VotarVereadores(List<Partido> partidos, List<Vereador> vereadores)
        {
            Console.Write("\nSEU VOTO PARA VEREADOR: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Vereador vereador in vereadores)
            {
                if (legenda == vereador.getLegenda())
                {
                    vereador.Votos();
                    TotalVotos.vtsValidosVer++;
                }
            }
        }

        private static void VotarPrefeitos(List<Prefeito> prefeitos)
        {
            Console.Write("\nSEU VOTO PARA PREFEITO: ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Prefeito prefeito in prefeitos)
            {
                if (legenda == prefeito.numeroPartido())
                {
                    prefeito.Votos(); //Adiciona 1 voto pro prefeito
                    TotalVotos.VtsValidosPref(); //Adiciona 1 voto valido geral
                }
            }
        }
        private static void ResultadoPrefeitos(List<Prefeito> prefeitos, int populacao)
        {
            Console.WriteLine("\nPREFEITOS\nVotos validos: " + TotalVotos.getVtsValidosPref() + " || Votos invalidos: " + TotalVotos.getVtsInvalidosPref(populacao));
            QuickSort(0, prefeitos.Count() - 1, prefeitos);
            double pct = 0, pctMax = 0;
            foreach (Prefeito prefeito in prefeitos)
            {
                pct = (double)(prefeito.getVotos() * 100) / TotalVotos.getVtsValidosPref();
                Console.WriteLine(prefeito.Nome() + "(" + prefeito.siglaPartido() + ")" + " || Votos: " + prefeito.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                if (pct > pctMax)
                    pctMax = pct;
            }

            if (pctMax < 51)
            {
                TotalVotos.vtsValidosPref = 0;
                int idade = 0;
                Console.WriteLine("\nSEGUNDO TURNO: ");
                List<Prefeito> segundoTurno = new List<Prefeito>();
                for (int i = 0; i < 2; i++)
                {
                    prefeitos[i].ZerarVotos();
                    segundoTurno.Add(prefeitos[i]);
                }
                for (int i = 0; i < populacao; i++)
                    SegundoTurnoPrefeitos(segundoTurno);
                foreach (Prefeito prefeito in segundoTurno)
                {
                    pct = (double)(prefeito.getVotos() * 100) / TotalVotos.getVtsValidosPref();
                    if (pct > 50)
                        Console.WriteLine("1° lugar: " + prefeito.Nome() + "(" + prefeito.siglaPartido() + ")" + " || Votos: " + prefeito.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
                    else if (pct < 50)
                        Console.WriteLine("2° lugar: " + prefeito.Nome() + "(" + prefeito.siglaPartido() + ")" + " || Votos: " + prefeito.getVotos() + " || Porcentagem: " + pct.ToString("F2", CultureInfo.InvariantCulture) + "%");
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
        private static void SegundoTurnoPrefeitos(List<Prefeito> segundoTurno)
        {
            Console.Write("\nSEU VOTO PARA PREFEITO (segundo turno): ");
            int legenda = int.Parse(Console.ReadLine());
            foreach (Prefeito prefeito in segundoTurno)
            {
                if (legenda == prefeito.numeroPartido())
                {
                    prefeito.Votos(); //Adiciona 1 voto pro prefeito
                    TotalVotos.VtsValidosPref(); //Adiciona 1 voto valido geral
                }
            }
        }

        private static void ImprimirMunicipais(List<Partido> partidos)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("LISTA DE PREFEITOS: ");
            foreach (Partido partido in partidos)
            {
                Console.WriteLine(partido.getPrefeito());
            }
            Console.WriteLine("\nLISTA DE VEREADORES:");
            foreach (Partido partido in partidos)
            {
                partido.getVereadores();
            }
            Console.WriteLine("-----------------------");
        }
        static void QuickSort(int esq, int dir, List<Prefeito> prefeitos)
        {
            int i = esq, j = dir;
            int pivo = prefeitos[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (prefeitos[i].getVotos() > pivo) i++;
                while (prefeitos[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    Prefeito temp = prefeitos[j];
                    prefeitos[j] = prefeitos[i];
                    prefeitos[i] = (Prefeito)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSort(esq, j, prefeitos);
            if (i < dir) QuickSort(i, dir, prefeitos);
        }
        static void QuickSortVer(int esq, int dir, List<Vereador> vereadores)
        {
            int i = esq, j = dir;
            int pivo = vereadores[(dir + esq) / 2].getVotos();
            while (i <= j)
            {
                while (vereadores[i].getVotos() > pivo) i++;
                while (vereadores[j].getVotos() < pivo) j--;
                if (i <= j)
                {
                    Vereador temp = vereadores[j];
                    vereadores[j] = vereadores[i];
                    vereadores[i] = (Vereador)temp;
                    i++;
                    j--;
                }
            }
            if (esq < j) QuickSortVer(esq, j, vereadores);
            if (i < dir) QuickSortVer(i, dir, vereadores);
        }
    }
}
