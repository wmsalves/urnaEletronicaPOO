using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
     interface Politico
     {       
        string Nome();
        int Idade();
        string ToString();
        void Votos();
        public int getVotos();
        Partido partido();
     }
}
