using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.PotionSystem
{
    public interface IConsumidor : IDemandado
    {
        public void Consumir(IContenedor pocion);

        public bool EnCondicionesParaSeguir();

        public bool Evaluacion();
    }
}
