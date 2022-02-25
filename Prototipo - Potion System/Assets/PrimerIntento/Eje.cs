using System;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [Serializable]
    public struct Eje
    {
        [SerializeField] private Dimension _dimension;
        private float _valor;

        public Eje(Dimension dimension, float valor = 0f)
        {
            _dimension = dimension;
            _valor = valor;
        }

        public void SetValor(float valor)
        {
            _valor = valor;
        }

        public bool Comparar(Eje eje)
        {
            return _dimension == eje._dimension;
        }

        public bool Comparar(Dimension dimension)
        {
            return _dimension == dimension;
        }

        public float GetValor()
        {
            return _valor;
        }

        public void Agregar(float valor)
        {
            _valor += valor;
        }
    }
}
