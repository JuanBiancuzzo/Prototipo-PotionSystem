using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Pocion : IPocion
    {
        private Atributos _atributos;

        public Pocion(Atributos atributos)
        {
            _atributos = atributos;
        }

        public Atributos GetAtributos()
        {
            return _atributos;
        }

        public float Distancia(IPocion posion)
        {
            return Atributos.Comparacion(_atributos, posion.GetAtributos());
        }

        public float Similitud(IPocion posion)
        {
            return Atributos.Similitud(_atributos, posion.GetAtributos());
        }

        public float Multiplicidad(IPocion posion)
        {
            return Atributos.Multiplicidad(_atributos, posion.GetAtributos());
        }
    }
}
