using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Crear_Alumno_Extranjero_Con_Numero_DNI_Argentino()
        {
            // Arrange
            Alumno alumno = new Alumno(4456, "Kendrick", "Lamar", "12345678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Crear_Profesor_Con_Numero_DNI_Invalido()
        {
            // Arrange
            Profesor profesor = new Profesor(1234, "Agustin", "Cruz", "123456789", Persona.ENacionalidad.Argentino);
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    // Arrange
        //    Profesor profesor = new Profesor(1234, "Agustin", "Cruz", "123456789", Persona.ENacionalidad.Argentino);
        //}
    }
}
