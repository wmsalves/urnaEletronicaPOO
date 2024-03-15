using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    static class TotalVotos
    {
        public static int vtsValidosPref = 0, vtsValidosVer = 0, vtsPres = 0, vtsGov = 0, vtsEstadual = 0, VtsFed = 0;


        public static void ZerarPref()
        {
            vtsValidosPref = 0;
        }
        public static void VtsValidosPref()
        {
            vtsValidosPref++;
        }
        public static int getVtsInvalidosVer(int populacao)
        {
            return populacao - vtsValidosVer;
        }
        public static int getVtsInvalidosPref(int populacao)
        {
            return populacao - vtsValidosPref;
        }
        public static int getVtsValidosPref()
        {
            return vtsValidosPref;
        }
        public static int getVtsEstadual()
        {
            return vtsEstadual;
        }
        public static int getVtsFederal()
        {
            return VtsFed;
        }
        public static int InvalidosGov(int populacao)
        {
            return populacao - vtsGov;
        }
        public static int InvalidosPres(int populacao)
        {
            return populacao - vtsPres;
        }
        public static int InvalidosFed(int populacao)
        {
            return populacao - VtsFed;
        }
        public static int InvalidosEst(int populacao)
        {
            return populacao - vtsEstadual;
        }
    }
}
