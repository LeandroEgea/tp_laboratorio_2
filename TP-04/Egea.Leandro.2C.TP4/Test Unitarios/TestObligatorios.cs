using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;

namespace Test_Unitarios
{
    [TestClass]
    public class TestObligatorios
    {
        [TestMethod]
        public void Verificar_Que_La_Lista_De_Paquetes_Del_Correo_Esta_Instanciada()
        {
            // Arrange
            Correo correo;
            // Act
            correo = new Correo();
            // Assert
            Assert.AreNotEqual(null, correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Verificar_Que_No_Se_Pueden_Cargar_Dos_Paquetes_Con_Mismo_TrackingID_En_Un_Correo()
        {
            // Arrange
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("CABA", "123456789");
            Paquete paqueteDos = new Paquete("Rosario", "123456789");
            // Act
            correo += paqueteUno;
            correo += paqueteDos;
        }
    }
}
