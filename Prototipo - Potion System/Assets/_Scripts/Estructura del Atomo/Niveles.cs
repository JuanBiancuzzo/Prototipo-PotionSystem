using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public partial struct Niveles
    {

        private List<Electron> _electrones;
        private List<uint> _divisiones;

        public Niveles(uint cantidadDePuntos, List<uint> divisiones, IElemento elemento)
        {
            _electrones = new List<Electron>();
            for (int i = 0; i < cantidadDePuntos; i++)
                _electrones.Add(new Electron());

            _divisiones = divisiones;
        }

        public Energia EnergiaPotencial()
        {
            return new Energia(DistanciaALosExtremos());
        }

        private int DistanciaALosExtremos()
        {
            int cantidad = _electrones.Count;

            int i = 0;
            for (; _divisiones.Count < (i + 1) && cantidad < _divisiones[i + 1]; i++);

            int inicio = 0;
            if (i > 0)
                inicio = (int)_divisiones[i - 1];
            int final = (int)_divisiones[i];

            int distanciaAlInicio = Mathf.Abs(inicio - cantidad);
            int distanciaAlFinal = Mathf.Abs(final - cantidad);

            return (distanciaAlInicio >= distanciaAlFinal) ? -distanciaAlInicio : distanciaAlFinal;
        }
    }
}