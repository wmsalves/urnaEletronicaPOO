using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class DepEstadual : Politico
    {
        private string nome;
        public Partido _partido;
        private int legenda, idade;
        private int votos = 0;
        public DepEstadual(string nome, int idade, Partido _partido, int legenda)
        {
            this.nome = nome;
            this._partido = _partido;
            this.idade = idade;
            this.legenda = legenda;
        }
        public void ZerarVotos()
        {
            votos = 0;
        }
        public string getSigla()
        {
            return _partido.getSigla();
        }

        public int getVotos()
        {
            return votos;
        }
        public void Votos()
        {
            votos++;
        }
        public int getLegenda()
        {
            return legenda;
        }
        public int Idade()
        {
            return idade;
        }
        public string Nome()
        {
            return nome;
        }
        public Partido partido()
        {
            return _partido;
        }
        public override string ToString()
        {
            return "Nome: " + Nome() + "|| Idade: " + Idade() + "|| Partido: " + _partido.getSigla() + "|| Legenda: " + legenda;
        }
    }
}
