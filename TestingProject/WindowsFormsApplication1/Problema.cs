using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Problema
    {
        Fraccion A, B, res;
        char operador=' ';
        void problema(Fraccion a, Fraccion b,char ope)
        {
            A = a;
            B = b;
            operador = ope;
            switch (ope)
            {
                case '+':
                    res = suma(a,b);
                    break;
                case '-':
                    res = resta(a, b);
                    break;
                case '*':
                    res = multi(a, b);
                    break;
                case '/':
                    res = divi(a, b);
                    break;
            }
        }

        public static long gcf(long a, long b)
        {
            long res = 1;
            for (int i = 2; i <= a && i <= b; )
            {
                if (a % i == 0 && b % i == 0)
                {
                    res *= i;
                    a = a / i;
                    b = b / i;
                }
                else
                {
                    i++;
                }
            }
            return res;
        }

        public static long lcd(long a, long b)
        {
            return 0;
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
            if (isZero(a))
            {
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
            a = simplificar(a);
            b = simplificar(b);
            Fraccion respuesta = new Fraccion();
            respuesta.num = (a.num * b.den) + (b.num * a.den);
                respuesta.den=a.den*b.den;
            return simplificar(respuesta);
        }

        static Fraccion resta(Fraccion a, Fraccion b)
        {
            a = simplificar(a);
            b = simplificar(b);
            Fraccion respuesta = new Fraccion();
            respuesta.num = (a.num * b.den) - (b.num * a.den);
            respuesta.den = a.den * b.den;
            return simplificar(respuesta);
        }

        static Fraccion multi(Fraccion a, Fraccion b)
        {
            var resultado = new Fraccion();
            a = simplificar(a);
            b = simplificar(b);
            resultado.den = a.den * b.den;
            resultado.den = a.num * b.num;
            return simplificar(resultado);
        }

        static Fraccion divi(Fraccion a, Fraccion b)
        {
            if (isZero(b))
            {
                throw new DivideByZeroException();
            }
            long c = b.den;
            b.den = b.num;
            b.num = c;
            return multi(a, b);
        }
    }
}
