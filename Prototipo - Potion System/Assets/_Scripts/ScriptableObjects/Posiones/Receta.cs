using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Receta para posion", menuName = "Posiones/Receta de posion")]
    public class Receta : ScriptableObject, IPocion
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

        private Pocion _posionBase = null;
        private Pocion _posion
        {
            get
            {
                if (_posionBase == null)
                {
                    List<Par> pares = new List<Par>();
                    foreach (ParIdValor par in _parIdValores)
                        pares.Add(new Par(par.Identificador, par.Valor));
                    _posionBase = new Pocion(new Atributos(pares));
                }
                return _posionBase;
            }
        }

        public Atributos GetAtributos()
        {
            return _posion.GetAtributos();
        }

        public float Distancia(IPocion posion)
        {
            return _posion.Distancia(posion);
        }

        public float Similitud(IPocion posion)
        {
            return _posion.Similitud(posion);
        }

        public float Multiplicidad(IPocion posion)
        {
            return _posion.Multiplicidad(posion);
        }
    }
}
