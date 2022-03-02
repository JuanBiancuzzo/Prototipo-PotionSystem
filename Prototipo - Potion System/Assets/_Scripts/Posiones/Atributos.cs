using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Atributos
    {
        private static float _valorNulo = 0f;
        private List<Par> _pares;

        public Atributos(List<Par> pares)
        {
            _pares = pares;
        }

        public float GetValor(IIdentificador identificador)
        {
            foreach (Par par in _pares)
                if (par.Comparar(identificador))
                    return par.GetValor();
            return _valorNulo;
        }

        public IEnumerable<IIdentificador> GetIdentificadores()
        {
            foreach (Par par in _pares)
                yield return par.GetIdentificador();
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

            if (moduloPropio == 0f)
                return 0f;
            return Mathf.Sign(Similitud(propio, otro)) * (moduloProyeccion / moduloPropio);
        }

        public static Atributos Sumar(Atributos propio, Atributos otro)
        {
            Tuple<Atributos, Atributos> atributosNuevos = AtributoGeneral(propio, otro);
            propio = atributosNuevos.Item1;
            otro = atributosNuevos.Item2;

            List<Par> paresNuevos = new List<Par>();
            for (int i = 0; i < propio._pares.Count; i++)
                paresNuevos.Add(Par.Sumar(propio._pares[i], otro._pares[i]));

            return new Atributos(paresNuevos);
        }

        public static Atributos Restar(Atributos propio, Atributos otro)
        {
            Tuple<Atributos, Atributos> atributosNuevos = AtributoGeneral(propio, otro);
            propio = atributosNuevos.Item1;
            otro = atributosNuevos.Item2;

            List<Par> paresNuevos = new List<Par>();
            for (int i = 0; i < propio._pares.Count; i++)
                paresNuevos.Add(Par.Restar(propio._pares[i], otro._pares[i]));

            return new Atributos(paresNuevos);
        }

        public static Atributos Multiplicar(Atributos atributos, float escalar)
        {
            List<Par> nuevosPares = new List<Par>();
            foreach (Par par in atributos._pares)
                nuevosPares.Add(Par.Multiplicar(par, escalar));
            return new Atributos(nuevosPares);
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
            float moduloCuadrado = ProductoInterno(propio, propio);
            float escalar = moduloCuadrado == 0f ? 0f : ProductoInterno(propio, otro) / moduloCuadrado; 
            return Multiplicar(propio, escalar);
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

        public static Atributos UnionNula(Atributos propio, Atributos otro)
        {
            List<Par> pares = new List<Par>();

            foreach (Par par in propio._pares)
                pares.Add(Par.CopiaNula(par));

            foreach (Par par in otro._pares)
                if (!Par.Existe(par, propio._pares))
                    pares.Add(Par.CopiaNula(par));

            return new Atributos(pares);
        }
    }
}
