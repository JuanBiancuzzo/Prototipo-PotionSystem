using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{

    public class Posion : IPosion
    {
        private Atributos _atributos;

        public Posion(Atributos atributo)
        {
            _atributos = atributo;
        }

        public Atributos GetAtributos()
        {
            return _atributos;
        }

        public float Distancia(IPosion posion)
        {
            return Atributos.Comparacion(posion.GetAtributos(), _atributos);
        }
    }
}
