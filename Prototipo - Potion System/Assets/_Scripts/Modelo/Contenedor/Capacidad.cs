using UnityEngine;

namespace ItIsNotOnlyMe.PotionSystem
{
    public class Capacidad : ICapacidad
    {
        private static int _minimoCapacidad = 1, _minimoCantidad = 0;
        private int _cantidad, _capacidad;

        public Capacidad(int capacidad)
        {
            _cantidad = _minimoCantidad;
            _capacidad = Mathf.Max(_minimoCapacidad, capacidad);
        }

        public void Agregar()
        {
            _cantidad = Mathf.Min(_cantidad + 1, _capacidad);
        }

        public void Reducir()
        {
            _cantidad = Mathf.Max(_cantidad - 1, _minimoCantidad);
        }

        public bool Vacio()
        {
            return _cantidad == _minimoCantidad;
        }

        public bool Lleno()
        {
            return _cantidad == _capacidad;
        }
    }
}
