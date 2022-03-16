using System;
using System.Collections.Generic;
using UnityEngine;
using ItIsNotOnlyMe.PotionSystem;
using ItIsNotOnlyMe.VectorDinamico;

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

        [SerializeField] private List<ParIdValor> _parIdValores;
        private Vector _atributos;

        public void Awake()
        {
            List<IComponente> pares = new List<IComponente>();
            foreach (ParIdValor par in _parIdValores)
                pares.Add(new Componente(par.Identificador, par.Valor));
            _atributos = new Vector(pares);
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
