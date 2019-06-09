using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            // Sleep ???
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        protected override string MostrarDatos()
        {
            throw new NotImplementedException(); //TODO
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase() //???
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            //sb.AppendLine(clasesDelDia.Dequeue().ToString());
            foreach (Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}