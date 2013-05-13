using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace WindowsFormsApplication2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_SIN_Parametros_Crea()
        {
            Fraccion f = new Fraccion();
            Assert.AreNotEqual(null, f);
        }

        [TestMethod]
        public void Constructor_Parametros_Crea()
        {
            Fraccion f = new Fraccion(7, 8);
            Assert.AreNotEqual(null, f);
        }

        [TestMethod]
        public void Constructor_SP_correctk()
        {
            Constructor_SIN_Parametros_Crea();
            Fraccion f = new Fraccion();
            bool boo = f.den == 1 && f.num == 1 && f.sig == signo.pos;
            Assert.IsTrue(boo);
        }

        [TestMethod]
        public void Constructor_Param_correctk_pos()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7,8);
            bool boo = f.den == 7 && f.num == 8 && f.sig == signo.pos;
            Assert.IsTrue(boo);
        }

        [TestMethod]
        public void Constructor_Param_correctk_neg()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, -8);
            bool boo = f.den == 7 && f.num == 8 && f.sig == signo.neg;
            Assert.IsTrue(boo);
        }

        [TestMethod]
        public void Constructor_Fail_zero()
        {
            Constructor_Parametros_Crea();
            try
            {
                Fraccion f = new Fraccion(0, 8);
            }
            catch (Exception e)
            {
                return;
            } Assert.Fail();
        }

        [TestMethod]
        public void isZero_funciona_true()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 0);
            Assert.IsTrue(Problema.isZero(f));
        }

        [TestMethod]
        public void isZero_funciona_false()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 1);
            Assert.IsTrue(!Problema.isZero(f));
        }

        [TestMethod]
        public void equals_funciona_identico_noZero()
        {
            isZero_funciona_false();
            
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 5);
            Fraccion g = new Fraccion(7, 5);
            Assert.IsTrue(Problema.sonIguales(f,g));
        }

        [TestMethod]
        public void equals_funciona_identico_Zero()
        {
            isZero_funciona_true();
            
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 0);
            Fraccion g = new Fraccion(7, 0);
            Assert.IsTrue(Problema.sonIguales(f,g));
        }

        [TestMethod]
        public void equals_funciona_no_identico_noZero()
        {
            isZero_funciona_false();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 5);
            Fraccion g = new Fraccion(14, 10);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_no_identico_Zero()
        {
            isZero_funciona_true();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(9, 0);
            Fraccion g = new Fraccion(7, 0);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_dif_noZero()
        {
            isZero_funciona_false();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 5);
            Fraccion g = new Fraccion(7, 6);
            Assert.IsTrue(!Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_dif_Zero()
        {
            isZero_funciona_true();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(7, 0);
            Fraccion g = new Fraccion(7, 9);
            Assert.IsTrue(!Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_todos()
        {
            equals_funciona_dif_noZero();
            equals_funciona_dif_Zero();
            equals_funciona_identico_noZero();
            equals_funciona_identico_Zero();
            equals_funciona_no_identico_noZero();
            equals_funciona_no_identico_Zero();
        }

        [TestMethod]
        public void divisionError()
        {
            isZero_funciona_true();
            Fraccion fe = new Fraccion(18, 0);
            Fraccion lao = new Fraccion();
            try
            {
                Problema.divi(lao, fe);
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void simplificar_nonZero()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 8);
            Fraccion res = new Fraccion(1, 2);
            f = Problema.simplificar(f);
            bool prueba = f.sig == res.sig && f.den == res.den && f.num == res.num;
            Assert.IsTrue(prueba);
        }

       [TestMethod]
        public void multi_same_sign_nonzero()
        {
            equals_todos();
            Fraccion f = new Fraccion(3, 4);
            Fraccion g = new Fraccion(4, 3);
            Fraccion res= new Fraccion(1,1);
            Assert.IsTrue(Problema.sonIguales(res,Problema.multi(f,g)));
        }
        [TestMethod]
        public void multi_same_sign_zero()
        {
            equals_todos();
            Fraccion f = new Fraccion(3, 4);
            Fraccion g = new Fraccion(4, 0);
            Fraccion res = new Fraccion(1, 0);
            Assert.IsTrue(Problema.sonIguales(res, Problema.multi(f, g)));
        }

        [TestMethod]
        public void suma_misma_base()
        {
            equals_todos();
            Fraccion f = new Fraccion(8, 4);
            Fraccion g = new Fraccion(8, 3);
            Fraccion res = new Fraccion(8, 7);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void suma_distinta_base()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 2);
            Fraccion g = new Fraccion(2, 1);
            Fraccion res = new Fraccion(9, 9);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }
    }
}
