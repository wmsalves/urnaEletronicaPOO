using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Partido
    {
        private string name;
        private string sigla;
        private int legenda;
        private Presidente presidente;
        private Gorvenador gorvenador;
        private Prefeito prefeito;
        public int numPresidente = 0, numGorvenador = 0, numPrefeito = 0, countDepEstaduais = 0, countDepFederais = 0, countVereadores = 0,
            vtsVereadores = 0;
        private List<DepEstadual> depEstaduaisPartido = new List<DepEstadual>();
        private List<Presidente>PresidentePartido = new List<Presidente>();
        private List<DepFederal> depFederaisPartido = new List<DepFederal>();
        public List<Vereador> vereadoresPartido = new List<Vereador>();

        public Partido(string name, string sigla, int legenda)
        {
            this.name = name;
            this.sigla = sigla;
            this.legenda = legenda;
        }
        public void numVotosVereador(int legendaver)
        {
            vtsVereadores++;
            foreach (Vereador vereador in vereadoresPartido)
            {
                if (legendaver == vereador.getLegenda())
                    vereador.Votos();
            }
        }

        public void numVotosPresidente(int legendaver)
        {
            numPresidente++;
            foreach (Presidente presidente in PresidentePartido)
            {
                if (legendaver == presidente.numeroPartido())
                    presidente.Votos();
            }
        }
        public void setVereadores(Vereador vereadores)
        {
            vereadoresPartido.Add(vereadores);
            countVereadores++;
        }
        public void setDepEstaduais(DepEstadual depEstadual)
        {
            depEstaduaisPartido.Add(depEstadual);
            countDepEstaduais++;
        }
        public void setDepFederais(DepFederal depFederal)
        {
            depFederaisPartido.Add(depFederal);
            countDepFederais++;
        }
        public void getVereadores()
        {
            foreach (Vereador vereador in vereadoresPartido)
            {
                Console.WriteLine(vereador);
            }
        }
        public void getDepFederais()
        {
            foreach (DepFederal depFederal in depFederaisPartido)
            {
                Console.WriteLine(depFederal);
            }
        }
        public void getDepEstaduais()
        {
            foreach (DepEstadual depEstadual in depEstaduaisPartido)
            {
                Console.WriteLine(depEstadual);
            }
        }
        public void setPresidente(Presidente presidente)
        {
            this.presidente = presidente;
            numPresidente++;
        }
        public void setGorvenador(Gorvenador gorvenador)
        {
            this.gorvenador = gorvenador;
            numGorvenador++;
        }
        public void setPrefeito(Prefeito prefeito)
        {
            this.prefeito = prefeito;
            numPrefeito++;
        }
        public Gorvenador getGorvenador()
        {
            return gorvenador;
        }
        public Presidente getPresidente()
        {
            return presidente;
        }
        public Prefeito getPrefeito()
        {
            return prefeito;
        }
        public int getLegenda()
        {
            return legenda;
        }
        public string getSigla()
        {
            return sigla;
        }
        public string getName()
        {
            return name;
        }
        public override string ToString()
        {
            return "Nome: " + name + " || Sigla: " + sigla + " || Legenda: " + legenda;
        }
    }
}
