using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Posion : IPosion
    {
        private Propiedades _propiedades;

        public Posion(Propiedades propiedades)
        {
            _propiedades = propiedades;
        }

        public Propiedades GetPropiedades()
        {
            return _propiedades;
        }

        public float Distancia(IPosion posion)
        {
            return Propiedades.Comparacion(_propiedades, posion.GetPropiedades());
        }

        public float Similitud(IPosion posion)
        {
            return Propiedades.Similitud(_propiedades, posion.GetPropiedades());
        }

        public float Multiplicidad(IPosion posion)
        {
            return Propiedades.Multiplicdad(_propiedades, posion.GetPropiedades());
        }
    }
}
