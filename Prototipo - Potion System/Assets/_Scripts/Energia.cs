using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Energia 
    {
        private int _cantidad; // que la energia puede ser negativa

        public Energia (int cantidad = 0)
        {
            _cantidad = cantidad;
        }

        public static Energia Abs(Energia energia)
        {
            return new Energia(Mathf.Abs(energia._cantidad));
        }

        public static Energia Sumar(Energia energia1, Energia energia2)
        {
            return new Energia(energia1._cantidad + energia2._cantidad);
        }

        public static Energia Restar(Energia energia1, Energia energia2)
        {
            return new Energia(energia1._cantidad - energia2._cantidad);
        }

        public static bool EsMayor(Energia energia1, Energia energia2)
        {
            int resultado = Comparacion(energia1, energia2);

            return resultado > 0;
        }

        private static int Comparacion(Energia energia1, Energia energia2)
        {
            if (energia1._cantidad == energia2._cantidad)
                return 0;

            if (energia1._cantidad > energia2._cantidad)
                return 1;
            return -1;
        }
    }
}