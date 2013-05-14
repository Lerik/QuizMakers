using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Problema
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
            if (a == b)
            {
                return a;
            }
            long res = 0;

            return res;
        }

        public static Fraccion simplificar(Fraccion f)
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

        public static bool isZero(Fraccion f)
        {
            return f.num == 0;
        }

        public static bool sonIguales(Fraccion a, Fraccion b)
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
        public static Fraccion suma(Fraccion a, Fraccion b)
        {
            a = simplificar(a);
            b = simplificar(b);
            Fraccion respuesta = new Fraccion();
            if (isZero(a))
            {
                return b;
            }
            if (isZero(b))
            {
                return a;
            }
            if (a.sig != b.sig)
            {
                b.sig = b.sig == signo.pos ? signo.neg : signo.pos;
                return resta(a, b);
            }
            respuesta.num = (a.num * b.den) + (b.num * a.den);
                respuesta.den=a.den*b.den;
                respuesta.sig = a.sig;
            return simplificar(respuesta);
        }

        public static Fraccion resta(Fraccion a, Fraccion b)
        {
            a = simplificar(a);
            b = simplificar(b);
            if (isZero(b))
            {
                return a;
            }
            if (isZero(a))
            {
                b.sig = b.sig == signo.pos ? signo.neg : signo.pos;
                return b;
            }
            if (a.sig != b.sig)
            {
                b.sig = b.sig == signo.pos ? signo.neg : signo.pos;
                return suma(a,b);
            }
            Fraccion respuesta = new Fraccion();
            respuesta.num = (a.num * b.den) - (b.num * a.den);
            if (respuesta.num < 0)
            {
                respuesta.num *= -1;
                respuesta.sig = a.sig == signo.pos ? signo.neg : signo.pos;
            }
            respuesta.den = a.den * b.den;
            return simplificar(respuesta);
        }

        public static Fraccion multi(Fraccion a, Fraccion b)
        {
            var resultado = new Fraccion();
            a = simplificar(a);
            b = simplificar(b);
            resultado.den = a.den * b.den;
            resultado.num = a.num * b.num;
            resultado.sig = a.sig == b.sig ? signo.pos : signo.neg;
            return simplificar(resultado);
        }

        public static Fraccion divi(Fraccion a, Fraccion b)
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
