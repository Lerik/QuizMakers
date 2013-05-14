using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum signo
    {
        pos = 1,
        neg = -1
    } 
    public class Fraccion
    {
        public long num;
        public long den;
        public signo sig;

       
        public Fraccion(long nume, long deno)
        {
            if (deno == 0)
            {
                throw new ArgumentException();
            }
            bool equiv = Math.Sign(deno) == Math.Sign(nume);
            sig = equiv?signo.pos:signo.neg;
            den = deno*Math.Sign(deno);
            num = nume*Math.Sign(nume);
        }

        public Fraccion()
        {
            sig = signo.pos;
            den = 1;
            num = 1;
        }
        
        

        
    }
}
