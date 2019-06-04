using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        static Profesor() //???
        {

        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, Universitario.ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

        }

        private void _randomClases()
        {
            throw new NotImplementedException(); //TODO
        }

        protected override string MostrarDatos()
        {
            throw new NotImplementedException(); //TODO
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            throw new NotImplementedException(); //TODO
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            throw new NotImplementedException(); //TODO
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}