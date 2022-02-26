using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Posion : IPosion
    {
        private Atributos _atributos;

        public Posion(Atributos atributos)
        {
            _atributos = atributos;
        }

        public Atributos GetAtributos()
        {
            return _atributos;
        }

        public float Distancia(IPosion posion)
        {
            return Atributos.Comparacion(_atributos, posion.GetAtributos());
        }

        public float Similitud(IPosion posion)
        {
            return Atributos.Similitud(_atributos, posion.GetAtributos());
        }

        public float Multiplicidad(IPosion posion)
        {
            return Atributos.Multiplicidad(_atributos, posion.GetAtributos());
        }
    }
}
