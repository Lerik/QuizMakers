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

        static long gcf(long a, long b)
        {
            long res = 1;
            for (int i = 2; i <= a && i <= b;)
            {
                if(a%i==0&&b%i==0){
                    res *= i;
                    a = a / i;
                    b = b / i;
                }else{
                    i++;
                }
            }
            return res;
        }

        static long lcd(long a, long b)
        {
            return 0;
        }
        Fraccion(long deno, long nume)
        {
            if (deno == 0)
            {
                throw new ArgumentException();
            }
            bool equiv = Math.Sign(deno) == Math.Sign(nume);
            sig = equiv?signo.pos:signo.neg;
            den = deno;
            num = nume;
        }

        Fraccion()
        {
            sig = signo.pos;
            den = 1;
            num = 1;
        }
        
        static Fraccion simplificar(Fraccion f)
        {
            if (isZero(f))
            {
                f.den = 1;
                f.sig = signo.pos;
            }
            long gfc = gcf(f.den, f.num);
            f.den /= gfc;
            f.num /= gfc;
            return f;
        }

        static bool isZero(Fraccion f)
        {
            return f.num == 0;
        }

        static bool sonIguales(Fraccion a, Fraccion b)
        {
           if(isZero(a)){
               return isZero(b);
           }
           if (isZero(b))
               return false;
           if (a.sig != b.sig)
           {
               return false;
           }
           return a.den / b.den == a.num / b.num;
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
            var resultado = new Fraccion();
            a = simplificar(a);
            b = simplificar(b);
            //todo
            return simplificar(resultado);
        }

        static Fraccion divi(Fraccion a, Fraccion b) 
        {
            if(isZero(b)){
                throw new DivideByZeroException();
            }
            long c = b.den;
            b.den = b.num;
            b.num = c;
            return multi(a, b);
        }
    }
}
