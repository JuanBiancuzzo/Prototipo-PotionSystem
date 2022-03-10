using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class ResultadoPrueba : IResultado
    {
        private Vector _atributos;

        public ResultadoPrueba(Vector atributos)
        {
            _atributos = atributos;
        }

        public float Distancia(IResultado resultado)
        {
            return resultado.Distancia(_atributos);
        }

        public float Distancia(Vector atributos)
        {
            return MathfVectores.Distancia(atributos, _atributos);
        }

        public float Similitud(IResultado resultado)
        {
            return resultado.Similitud(_atributos);
        }

        public float Similitud(Vector atributos)
        {
            return MathfVectores.Similitud(atributos, _atributos);
        }

        public float Multiplicidad(IResultado resultado)
        {
            return resultado.Multiplicidad(_atributos);
        }

        public float Multiplicidad(Vector atributos)
        {
            return MathfVectores.Multiplicdad(atributos, _atributos);
        }
    }
}