using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Atributos
    {
        private List<Par> _pares;

        public Atributos(List<Par> pares)
        {
            _pares = pares;
        }

        public static float Comparacion(Atributos propio, Atributos otro)
        {
            Tuple<Atributos, Atributos> atributosNuevos = AtributoGeneral(propio, otro);
            propio = atributosNuevos.Item1;
            otro = atributosNuevos.Item2;

            List<Par> paresNuevos = new List<Par>();
            for (int i = 0; i < propio._pares.Count; i++)
                paresNuevos.Add(Par.Restar(propio._pares[i], otro._pares[i]));

            return Modulo(new Atributos(paresNuevos));
        }

        public static float Similitud(Atributos propio, Atributos otro)
        {
            return ProductoInterno(Normalizar(propio), Normalizar(otro));
        }

        public static float Multiplicidad(Atributos propio, Atributos otro)
        {
            Atributos otroProyectado = Proyeccion(propio, otro);

            float moduloPropio = Modulo(propio);
            float moduloProyeccion = Modulo(otroProyectado);

            return Mathf.Sign(Similitud(propio, otro)) * (moduloProyeccion / moduloPropio);
        }

        private static float ProductoInterno(Atributos propio, Atributos otro)
        {
            Tuple<Atributos, Atributos> atributosNuevos = AtributoGeneral(propio, otro);
            propio = atributosNuevos.Item1;
            otro = atributosNuevos.Item2;

            float producto = 0f;
            for (int i = 0; i < propio._pares.Count; i++)
                producto += Par.Multiplicar(propio._pares[i], otro._pares[i]);
            return producto;
        }

        private static float Modulo(Atributos atributos)
        {
            return Mathf.Sqrt(ProductoInterno(atributos, atributos));
        }

        private static Atributos Normalizar(Atributos atributos)
        {
            float modulo = Modulo(atributos);
            List<Par> nuevosPares = new List<Par>();

            foreach (Par par in atributos._pares)
                nuevosPares.Add(Par.Dividir(par, modulo));

            return new Atributos(nuevosPares);
        }

        private static Atributos Proyeccion(Atributos propio, Atributos otro)
        {
            float escalar = ProductoInterno(propio, otro) / ProductoInterno(propio, propio);
            return Multiplicar(propio, escalar);
        }

        private static Atributos Multiplicar(Atributos atributos, float escalar)
        {
            List<Par> nuevosPares = new List<Par>();
            foreach (Par par in atributos._pares)
                nuevosPares.Add(Par.Multiplicar(par, escalar));
            return new Atributos(nuevosPares);
        }

        private static Tuple<Atributos, Atributos> AtributoGeneral(Atributos propio, Atributos otro)
        {
            List<Par> paresPropio = new List<Par>(), paresOtro = new List<Par>();

            foreach (Par parPropio in propio._pares)
            {
                Par par = Par.CopiaNula(parPropio);
                foreach (Par parOtro in otro._pares)
                {
                    if (parPropio.Comparar(parOtro))
                        par = parOtro;
                }

                paresPropio.Add(parPropio);
                paresOtro.Add(par);
            }

            foreach (Par parOtro in otro._pares)
            {
                if (Par.Existe(parOtro, propio._pares))
                    continue;

                paresOtro.Add(parOtro);
                paresPropio.Add(Par.CopiaNula(parOtro));
            }

            return new Tuple<Atributos, Atributos>(new Atributos(paresPropio), new Atributos(paresOtro));
        }
    }
}
