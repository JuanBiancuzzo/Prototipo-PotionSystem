using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Resultado : IResultado
    {
        private Atributos _atributos;

        public Resultado(Atributos atributos)
        {
            _atributos = atributos;
        }

        public float Distancia(IResultado resultado)
        {
            return resultado.Distancia(_atributos);
        }

        public float Distancia(Atributos atributos)
        {
            return Atributos.Comparacion(atributos, _atributos);
        }

        public float Similitud(IResultado resultado)
        {
            return resultado.Similitud(_atributos);
        }

        public float Similitud(Atributos atributos)
        {
            return Atributos.Similitud(atributos, _atributos);
        }

        public float Multiplicidad(IResultado resultado)
        {
            return resultado.Multiplicidad(_atributos);
        }

        public float Multiplicidad(Atributos atributos)
        {
            return Atributos.Multiplicidad(atributos, _atributos);
        }
    }
}
