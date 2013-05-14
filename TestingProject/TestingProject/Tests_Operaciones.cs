using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace WindowsFormsApplication2
{
    [TestClass]
    public class Tests_Operaciones
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
            Fraccion f = new Fraccion(8, 7);
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
            Fraccion f = new Fraccion(8, 7);
            bool boo = f.den == 7 && f.num == 8 && f.sig == signo.pos;
            Assert.IsTrue(boo);
        }

        [TestMethod]
        public void Constructor_Param_correctk_neg()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(-8, 7);
            bool boo = f.den == 7 && f.num == 8 && f.sig == signo.neg;
            Assert.IsTrue(boo);
        }

        [TestMethod]
        public void Constructor_Fail_zero()
        {
            Constructor_Parametros_Crea();
            try
            {
                Fraccion f = new Fraccion(8, 0);
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
            Fraccion f = new Fraccion(0, 7);
            Assert.IsTrue(Problema.isZero(f));
        }

        [TestMethod]
        public void isZero_funciona_false()
        {
            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(1, 7);
            Assert.IsTrue(!Problema.isZero(f));
        }

        [TestMethod]
        public void equals_funciona_identico_noZero()
        {
            isZero_funciona_false();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(5, 7);
            Fraccion g = new Fraccion(5, 7);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_identico_Zero()
        {
            isZero_funciona_true();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(0, 7);
            Fraccion g = new Fraccion(0, 7);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_no_identico_noZero()
        {
            isZero_funciona_false();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(5, 7);
            Fraccion g = new Fraccion(10, 14);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_no_identico_Zero()
        {
            isZero_funciona_true();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(0, 9);
            Fraccion g = new Fraccion(0, 7);
            Assert.IsTrue(Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_dif_noZero()
        {
            isZero_funciona_false();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(5, 7);
            Fraccion g = new Fraccion(6, 7);
            Assert.IsTrue(!Problema.sonIguales(f, g));
        }

        [TestMethod]
        public void equals_funciona_dif_Zero()
        {
            isZero_funciona_true();

            Constructor_Parametros_Crea();
            Fraccion f = new Fraccion(0, 7);
            Fraccion g = new Fraccion(9, 7);
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
            Fraccion fe = new Fraccion(0, 18);
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
            Fraccion f = new Fraccion(8, 4);
            Fraccion res = new Fraccion(2, 1);
            f = Problema.simplificar(f);
            bool prueba = f.sig == res.sig && f.den == res.den && f.num == res.num;
            Assert.IsTrue(prueba);
        }

        [TestMethod]
        public void multi_same_sign_nonzero()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 3);
            Fraccion g = new Fraccion(3, 4);
            Fraccion res = new Fraccion(1, 1);
            Fraccion pre= Problema.multi(f, g);
            Assert.IsTrue(Problema.sonIguales(res, pre));
        }


        [TestMethod]
        public void multi_zero()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 3);
            Fraccion g = new Fraccion(0, 4);
            Fraccion res = new Fraccion(0, 1);
            Assert.IsTrue(Problema.sonIguales(res, Problema.multi(f, g)));
        }

        [TestMethod]
        public void simplificar_Zero_pos()
        {
            equals_todos();
            Fraccion f = new Fraccion(0, 4);
            f = Problema.simplificar(f);
            bool prueba = f.sig == signo.pos && f.den == 1 && f.num == 0;
            Assert.IsTrue(prueba);
        }

        [TestMethod]
        public void simplificar_Zero_neg()
        {
            equals_todos();
            Fraccion f = new Fraccion(0, -4);
            f = Problema.simplificar(f);
            bool prueba = f.sig == signo.pos && f.den == 1 && f.num == 0;
            Assert.IsTrue(prueba);
        }
        [TestMethod]
        public void multi_dif_sign_nonzero()
        {
            equals_todos();
            Fraccion f = new Fraccion(-4, 3);
            Fraccion g = new Fraccion(3, 4);
            Fraccion res = new Fraccion(-1, 1);
            Fraccion pre = Problema.multi(f, g);
            Assert.IsTrue(Problema.sonIguales(res, pre));
        }



        [TestMethod]
        public void suma_misma_base_pos()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 8);
            Fraccion g = new Fraccion(3, 8);
            Fraccion res = new Fraccion(7, 8);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void suma_distinta_base_pos()
        {
            equals_todos();
            Fraccion f = new Fraccion(2, 4);
            Fraccion g = new Fraccion(1, 2);
            Fraccion res = new Fraccion(9, 9);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void suma_misma_base_mixed()
        {
            equals_todos();
            Fraccion f = new Fraccion(4, 8);
            Fraccion g = new Fraccion(-3, 8);
            Fraccion res = new Fraccion(1, 8);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void suma_distinta_base_mixed()
        {
            equals_todos();
            Fraccion f = new Fraccion(5, 4);
            Fraccion g = new Fraccion(-1, 2);
            Fraccion res = new Fraccion(3, 4);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        public void suma_misma_base_neg()
        {
            equals_todos();
            Fraccion f = new Fraccion(-4, 8);
            Fraccion g = new Fraccion(-3, 8);
            Fraccion res = new Fraccion(-7, 8);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void suma_distinta_base_neg()
        {
            equals_todos();
            Fraccion f = new Fraccion(-2, 4);
            Fraccion g = new Fraccion(1, -2);
            Fraccion res = new Fraccion(-9, 9);
            Assert.IsTrue(Problema.sonIguales(res, Problema.suma(f, g)));
        }

        [TestMethod]
        public void division_same_sign_pos()
        {
            multi_same_sign_nonzero();
            Fraccion la = new Fraccion(3, 5);
            Fraccion le = new Fraccion(6, 7);
            Fraccion res = new Fraccion(7, 10);
            la = Problema.divi(la, le);
            Assert.IsTrue(Problema.sonIguales(la,res));
        }

        [TestMethod]
        public void division_dif_sign()
        {
            multi_dif_sign_nonzero();
            Fraccion la = new Fraccion(3, -5);
            Fraccion le = new Fraccion(6, 7);
            Fraccion res = new Fraccion(-7, 10);
            la = Problema.divi(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void division_zero()
        {
            multi_zero();
            Fraccion la = new Fraccion(0, 5);
            Fraccion le = new Fraccion(6, 7);
            Fraccion res = new Fraccion(0, 10);
            la = Problema.divi(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void resta_mismo_signo_menor()
        {
            equals_todos();
            Fraccion la = new Fraccion(8, 5);
            Fraccion le = new Fraccion(6, 5);
            Fraccion res = new Fraccion(2, 5);
            la = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void resta_mismo_signo_mayor()
        {
            equals_todos();
            Fraccion la = new Fraccion(-6, 5);
            Fraccion le = new Fraccion(-8, 5);
            Fraccion res = new Fraccion(2, 5);
            la = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void resta_dif_signo_menor()
        {
            equals_todos();
            Fraccion la = new Fraccion(17, 5);
            Fraccion le = new Fraccion(-6, 5);
            Fraccion res = new Fraccion(23, 5);
            la = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void resta_dif_signo_mayor()
        {
            equals_todos();
            Fraccion la = new Fraccion(-17, 5);
            Fraccion le = new Fraccion(6, 5);
            Fraccion res = new Fraccion(-23, 5);
            la = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }

        [TestMethod]
        public void resta_a_zero()
        {
            equals_todos();
            Fraccion la = new Fraccion(-17, 5);
            Fraccion le = new Fraccion(0, 5);
            
            le = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, le));
        }

        [TestMethod]
        public void resta_de_zero()
        {
            equals_todos();
            Fraccion la = new Fraccion(0, 5);
            Fraccion le = new Fraccion(6, 5);
            Fraccion res = new Fraccion(6, -5);
            la = Problema.resta(la, le);
            Assert.IsTrue(Problema.sonIguales(la, res));
        }
    }
}