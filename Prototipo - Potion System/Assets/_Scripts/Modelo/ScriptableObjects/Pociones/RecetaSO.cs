﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Receta para posion", menuName = "Posiones/Receta de posion")]
    public class RecetaSO : ScriptableObject, IResultado
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

        private Resultado _pocionBase = null;
        private Resultado _pocion
        {
            get
            {
                if (_pocionBase == null)
                {
                    List<Par> pares = new List<Par>();
                    foreach (ParIdValor par in _parIdValores)
                        pares.Add(new Par(par.Identificador, par.Valor));
                    _pocionBase = new Resultado(new Atributos(pares));
                }
                return _pocionBase;
            }
        }

        public float Distancia(IResultado posion)
        {
            return _pocion.Distancia(posion);
        }

        public float Distancia(Atributos atributos)
        {
            return _pocion.Distancia(atributos);
        }

        public float Similitud(IResultado posion)
        {
            return _pocion.Similitud(posion);
        }

        public float Similitud(Atributos atributos)
        {
            return _pocion.Similitud(atributos);
        }

        public float Multiplicidad(IResultado posion)
        {
            return _pocion.Multiplicidad(posion);
        }

        public float Multiplicidad(Atributos atributos)
        {
            return _pocion.Multiplicidad(atributos);
        }
    }
}
