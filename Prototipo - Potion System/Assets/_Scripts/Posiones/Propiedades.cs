using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public struct Propiedades
    {
        public float Vida, Temperatura, Visibilidad, Velocidad, Estado, Densidad;

        public Propiedades(float vida, float temperatura, float visibilidad, 
                         float velocidad, float estado, float peso)
        {
            Vida = vida;
            Temperatura = temperatura;
            Visibilidad = visibilidad;
            Velocidad = velocidad;
            Estado = estado;
            Densidad = peso;
        }

        public Propiedades(List<float> valores)
        {
            Vida = valores[0];
            Temperatura = valores[1];
            Visibilidad = valores[2];
            Velocidad = valores[3];
            Estado = valores[4];
            Densidad = valores[5];
        }

        public static float Comparacion(Propiedades propio, Propiedades otro)
        {
            List<float> valoresPropios = Valores(propio);
            List<float> valoresOtro = Valores(otro);

            List<float> diferencia = new List<float>();
            for (int i = 0; i < valoresPropios.Count; i++)
                diferencia.Add(valoresPropios[i] - valoresOtro[i]);

            return Modulo(new Propiedades(diferencia));
        }

        public static float Similitud(Propiedades propio, Propiedades otro)
        {
            return ProductoInterno(Normalizar(propio), Normalizar(otro));
        }

        public static float Multiplicdad(Propiedades propio, Propiedades otro)
        {
            Propiedades otroProyectado = Proyeccion(propio, otro);

            float moduloPropio = Modulo(propio);
            float moduloProyeccion = Modulo(otroProyectado);

            return moduloPropio / moduloProyeccion;
        }

        private static float ProductoInterno(Propiedades propio, Propiedades otro)
        {
            List<float> valoresPropios = Valores(propio);
            List<float> valoresOtro = Valores(otro);

            float producto = 0f;
            for (int i = 0; i < valoresPropios.Count; i++)
                producto += valoresPropios[i] * valoresOtro[i];

            return producto;
        }

        private static float Modulo(Propiedades propiedades)
        {
            return Mathf.Sqrt(ProductoInterno(propiedades, propiedades));
        }

        private static Propiedades Normalizar(Propiedades propiedades)
        {
            List<float> valores = Valores(propiedades);
            float modulo = Modulo(propiedades);

            for (int i = 0; i < valores.Count; i++)
                valores[i] /= modulo;

            return new Propiedades(valores);
        }

        private static Propiedades Proyeccion(Propiedades propio, Propiedades otro)
        {
            float escalar = ProductoInterno(propio, otro) / Mathf.Pow(Modulo(propio), 2);
            return Multiplicar(propio, escalar);
        }

        private static Propiedades Multiplicar(Propiedades propiedades, float escalar)
        {
            List<float> valores = Valores(propiedades);
            for (int i = 0; i < valores.Count; i++)
                valores[i] *= escalar;
            return new Propiedades(valores);
        }

        private static List<float> Valores(Propiedades atributos)
        {
            return new List<float>
            {
                atributos.Vida,
                atributos.Temperatura,
                atributos.Visibilidad,
                atributos.Velocidad,
                atributos.Estado,
                atributos.Densidad
            };
        }
    }
}
