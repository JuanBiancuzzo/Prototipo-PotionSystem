using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Carga
    {
        private int _cantidad;

        public Carga(int cantidad = 0)
        {
            _cantidad = cantidad;
        }

        public static Carga Abs(Carga carga)
        {
            return new Carga(Mathf.Abs(carga._cantidad));
        }

        public static Carga Sumar(Carga carga1, Carga carga2)
        {
            return new Carga(carga1._cantidad + carga2._cantidad);
        }

        public static Carga Restar(Carga carga1, Carga carga2)
        {
            return new Carga(carga1._cantidad - carga2._cantidad);
        }

        public static bool EsMayor(Carga carga1, Carga carga2)
        {
            int resultado = Comparacion(carga1, carga2);

            return resultado > 0;
        }

        private static int Comparacion(Carga carga1, Carga carga2)
        {
            if (carga1._cantidad == carga2._cantidad)
                return 0;

            if (carga1._cantidad > carga2._cantidad)
                return 1;
            return -1;
        }
    }
}