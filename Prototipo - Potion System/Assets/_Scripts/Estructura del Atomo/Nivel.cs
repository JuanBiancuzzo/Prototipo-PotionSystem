using System;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [Serializable]
    public struct Nivel
    {
        [SerializeField] private uint _nivelActual;
        [SerializeField] private uint _capacidadNivel;

        public Nivel(uint capacidadNivel, uint nivelActual = 0)
        {
            _capacidadNivel = capacidadNivel;
            _nivelActual = nivelActual;
        }

        public Energia GetEnergia()
        {
            return new Energia(CantidadAExtremos());
        }

        private int CantidadAExtremos()
        {
            int distanciaAlPrincipio = (-1) * (int)_nivelActual;
            int distanciaAlFinal = (int)(_capacidadNivel - _nivelActual);

            // se favorece tener menos energia
            if (Mathf.Abs(distanciaAlPrincipio) > Mathf.Abs(distanciaAlFinal))
                return distanciaAlPrincipio;
            return distanciaAlFinal;
        }
    }
}