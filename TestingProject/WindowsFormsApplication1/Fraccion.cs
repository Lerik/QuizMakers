using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    class Fraccion
    {
        enum signo{
            pos= 1,
            neg= -1
        } 

        long num;
        long den; 
        signo sig;

        static Fraccion simplificar(Fraccion f)
        {
            return f;
        }

        static bool isZero(Fraccion f)
        {
            return f.num == 0;
        }

        static bool sonIguales(Fraccion a, Fraccion b)
        {
            //por retornar un valor, luego lo cambio
            return a.den == b.den && a.num == b.num &&a.sig==b.sig;
        }

        static Fraccion suma(Fraccion a, Fraccion b)
        {
            //Implementar
            return null;
        }

        static Fraccion resta(Fraccion a, Fraccion b)
        {
            //Implementar
            return null;
        }

        static Fraccion multi(Fraccion a, Fraccion b)
        {
            //Implementar
            return null;
        }

        static Fraccion divi(Fraccion a, Fraccion b)
        {
            //Implementar
            return null;
        }
    }
}
