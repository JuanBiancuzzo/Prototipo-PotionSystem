using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public interface IConsumidor : IDemandado
    {
        public void Consumir(IContenedor pocion);

        public float Evaluacion();

        public bool EnCondicionesParaSeguir();
    }
}
