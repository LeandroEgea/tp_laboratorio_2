using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Test_Unitarios
{
    [TestClass]
    public class TestObligatorios
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Crear_Alumno_Extranjero_Con_Numero_DNI_Argentino()
        {
            // Arrange
            Alumno alumno;
            // Act
            alumno = new Alumno(4456, "Kendrick", "Lamar", "12345678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Crear_Profesor_Con_Numero_DNI_Invalido()
        {
            // Arrange
            Profesor profesor;
            // Act    
            profesor = new Profesor(1234, "Agustin", "Cruz", "123456789", Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        public void Crear_Alumno_Y_Verificar_DNI_Valido()
        {
            // Arrange
            Alumno alumno;
            // Act
            alumno = new Alumno(4456, "Kendrick", "Lamar", "99999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            // Assert
            Assert.AreEqual(99999999, alumno.DNI);
        }

        [TestMethod]
        public void Verificar_Que_Se_Carga_Jornada_En_Universidad()
        {
            // Arrange
            Universidad universidad;
            Profesor profesor;
            Jornada jornada;
            // Act
            universidad = new Universidad();
            profesor = new Profesor();
            jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            universidad[0] = jornada;
            // Assert
            Assert.IsNotNull(universidad[0]);
            Assert.AreSame(profesor, universidad[0]);
        }
    }
}
