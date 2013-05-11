using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public enum signo
    {
        pos = 1,
        neg = -1
    } 
    class Fraccion
    {
        public long num;
        public long den;
        public signo sig;

       
        public Fraccion(long deno, long nume)
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

        public Fraccion()
        {
            sig = signo.pos;
            den = 1;
            num = 1;
        }
        
        

        
    }
}
