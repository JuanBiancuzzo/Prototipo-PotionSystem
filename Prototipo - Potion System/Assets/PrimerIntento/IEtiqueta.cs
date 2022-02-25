using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public abstract class IEtiqueta
    {
        [Serializable]
        public struct Modificador
        {
            [SerializeField] public Dimension Dimension;
            [SerializeField] public float Factor;

            public Modificador(Dimension dimension, float factor)
            {
                Dimension = dimension;
                Factor = factor;
            }
        }

        public abstract float ValorParaModificar(Eje eje);
    }
}
