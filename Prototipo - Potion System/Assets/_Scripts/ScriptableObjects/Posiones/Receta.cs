using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Receta para posion", menuName = "Posiones/Receta de posion")]
    public class Receta : ScriptableObject, IPosion
    {
        [Serializable]
        private struct ParIdValor
        {
            [SerializeField] 
            public IdentificadorSO Identificador;

            [SerializeField] [Range(-20, 20)]
            public float Valor;
        }

        [SerializeField] List<ParIdValor> _parIdValores;

        private Posion _posionBase = null;
        private Posion _posion
        {
            get
            {
                if (_posionBase == null)
                {
                    List<Par> pares = new List<Par>();
                    foreach (ParIdValor par in _parIdValores)
                        pares.Add(new Par(par.Identificador, par.Valor));
                    _posionBase = new Posion(new Atributos(pares));
                }
                return _posionBase;
            }
        }

        public Atributos GetAtributos()
        {
            return _posion.GetAtributos();
        }

        public float Distancia(IPosion posion)
        {
            return _posion.Distancia(posion);
        }

        public float Similitud(IPosion posion)
        {
            return _posion.Similitud(posion);
        }

        public float Multiplicidad(IPosion posion)
        {
            return _posion.Multiplicidad(posion);
        }
    }
}
