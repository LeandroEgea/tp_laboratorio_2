using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Test_Unitarios
{
    [TestClass]
    public class TestPersona
    {
        //Nombre Y Apellido

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_Con_Nombre_Invalido()
        {
            // Arrange
            Alumno alumno;
            // Act
            alumno = new Alumno(4456, "Kendrick7", "Lamar", "92345678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        public void Constructor_Con_Nombre_Valido()
        {
            // Arrange
            Alumno alumno;
            string nombre = "Agustín Nicolas'-";
            // Act    
            alumno = new Alumno(1234, nombre, "Cruz", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            // Assert
            Assert.AreEqual(nombre, alumno.Nombre);
        }
    }
}
