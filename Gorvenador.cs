using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    class Gorvenador : Politico
    {

        private string nome;
        private int idade;
        private Partido _partido;
        private int votos = 0;

        public Gorvenador(string nome, int idade, Partido _partido)
        {
            this.nome = nome;
            this.idade = idade;
            this._partido = _partido;
        }
        public string Nome()
        {
            return nome;
        }
        public int Idade()
        {
            return idade;
        }
        public void Votos()
        {
            votos++;
        }
        public void ZerarVotos()
        {
            votos = 0;
        }
        public int numeroPartido()
        {
            return _partido.getLegenda();
        }
        public string siglaPartido()
        {
            return _partido.getSigla();
        }
        public string nomePartido()
        {
            return _partido.getName();
        }
        public Partido partido()
        {
            return _partido;
        }
        public override string ToString()
        {
            return "Nome: " + Nome() + "|| Idade: " + Idade() + "|| Partido: " + _partido.getSigla() + "|| Legenda: " + _partido.getLegenda();
        }

        public int getVotos()
        {
            return votos;
        }
    }


}
