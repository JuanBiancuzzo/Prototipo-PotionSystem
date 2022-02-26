using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public struct Atributos
    {
        public float Vida, Temperatura, Visivilidad, Velocidad, Estado, Peso;

        public Atributos(float vida, float temperatura, float visivilidad, 
                         float velocidad, float estado, float peso)
        {
            Vida = vida;
            Temperatura = temperatura;
            Visivilidad = visivilidad;
            Velocidad = velocidad;
            Estado = estado;
            Peso = peso;
        }

        public Atributos(List<float> valores)
        {
            Vida = valores[0];
            Temperatura = valores[1];
            Visivilidad = valores[2];
            Velocidad = valores[3];
            Estado = valores[4];
            Peso = valores[5];
        }

        private void Multiplicar(float escalar)
        {
            Vida *= escalar;
            Temperatura *= escalar;
            Visivilidad *= escalar;
            Velocidad *= escalar;
            Estado *= escalar;
            Peso *= escalar;
        }

        private Atributos Duplicar()
        {
            return new Atributos(Valores(this));
        }

        public static float Comparacion(Atributos propio, Atributos otro)
        {
            List<float> valoresPropios = Valores(propio);
            List<float> valoresOtro = Valores(otro);

            List<float> diferencia = new List<float>();
            for (int i = 0; i < valoresPropios.Count; i++)
                diferencia.Add(valoresPropios[i] - valoresOtro[i]);

            return Modulo(new Atributos(diferencia));
        }

        public static float Similitud(Atributos propio, Atributos otro)
        {
            return ProductoInterno(Normalizar(propio), Normalizar(otro));
        }

        public static float Multiplicdad(Atributos propio, Atributos otro)
        {
            Atributos otroProyectado = Proyeccion(propio, otro);

            float moduloPropio = Modulo(propio);
            float moduloProyeccion = Modulo(otro);

            return moduloPropio / moduloProyeccion;
        }

        private static float ProductoInterno(Atributos propio, Atributos otro)
        {
            List<float> valoresPropios = Valores(propio);
            List<float> valoresOtro = Valores(otro);

            float similitud = 0f;
            for (int i = 0; i < valoresPropios.Count; i++)
                similitud += valoresPropios[i] * valoresOtro[i];

            return similitud;
        }

        private static float Modulo(Atributos atributos)
        {
            return Mathf.Sqrt(ProductoInterno(atributos, atributos));
        }

        private static Atributos Normalizar(Atributos atributos)
        {
            List<float> valores = Valores(atributos);
            float modulo = Modulo(atributos);

            for (int i = 0; i < valores.Count; i++)
                valores[i] /= modulo;

            return new Atributos(valores);
        }

        private static Atributos Proyeccion(Atributos propio, Atributos otro)
        {
            float escalar = ProductoInterno(propio, otro) / Mathf.Pow(Modulo(propio), 2);
            Atributos nuevo = propio.Duplicar();
            nuevo.Multiplicar(escalar);
            return nuevo;
        }

        private static List<float> Valores(Atributos atributos)
        {
            return new List<float>
            {
                atributos.Vida,
                atributos.Temperatura,
                atributos.Visivilidad,
                atributos.Velocidad,
                atributos.Estado,
                atributos.Peso
            };
        }
    }
}
