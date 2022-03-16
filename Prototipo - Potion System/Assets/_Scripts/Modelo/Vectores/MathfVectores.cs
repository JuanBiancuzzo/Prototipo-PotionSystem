using UnityEngine;

namespace ItIsNotOnlyMe.VectorDinamico
{
    public static class MathfVectores
    {
        
        public static float Distancia(Vector vector, Vector otro)
        {
            Vector direccion = (Vector) vector.Restar(otro);
            return Modulo(direccion);
        }

        public static float Similitud(Vector vector, Vector otro)
        {
            return Normalizar(vector).ProductoInterno(Normalizar(otro));
        }

        public static float Multiplicdad(Vector vector, Vector otro)
        {
            Vector proyeccion = Proyeccion(vector, otro);

            float moduloPropio = Modulo(vector);
            float moduloProyeccion = Modulo(proyeccion);

            if (moduloPropio == 0f)
                return 0f;
            return Mathf.Sign(Similitud(vector, otro)) * (moduloProyeccion / moduloPropio);
        }

        private static Vector Proyeccion(Vector vector, Vector otro)
        {
            float moduloCuadrado = vector.ProductoInterno(vector);
            float escalar = (moduloCuadrado == 0f) ? 0f : vector.ProductoInterno(otro) / moduloCuadrado;
            return vector.Multiplicar(escalar);
        }

        private static Vector Normalizar(Vector vector)
        {
            float modulo = Modulo(vector);
            return vector.Dividir(modulo);
        }

        private static float Modulo(Vector vector)
        {
            return Mathf.Sqrt(vector.ProductoInterno(vector));
        }
    }
}
