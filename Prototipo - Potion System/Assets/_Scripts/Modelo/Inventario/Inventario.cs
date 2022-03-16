using System.Collections.Generic;

namespace ItIsNotOnlyMe.Inventario
{
    public class Inventario : IInventario
    {
        private int _capacidad;
        private List<Stack> _stacks;

        public Inventario(int capacidad)
        {
            _capacidad = capacidad;
            _stacks = new List<Stack>();
        }

        public bool Agregar(IItem item)
        {
            if (Lleno())
                return false;

            foreach (Stack stack in _stacks)
                if (stack.EsIgual(item))
                {
                    stack.Agregar(item);
                    return true;
                }

            _stacks.Add(new Stack(item));
            return true;
        }

        public bool Sacar(IItem item)
        {
            if (Vacio())
                return false;

            foreach (Stack stack in _stacks)
                if (stack.EsIgual(item))
                {
                    stack.Sacar(item);
                    if (stack.Vacio())
                        _stacks.Remove(stack);
                    return true;
                }

            _stacks.Add(new Stack(item));
            return true;
        }

        private bool Lleno()
        {
            return _stacks.Count >= _capacidad;
        }

        private bool Vacio()
        {
            return _stacks.Count == 0;
        }
    }
}
