using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public interface IInventario
    {
        public bool Agregar(IItem item);

        public bool Sacar(IItem item);
    }

    public struct Stack
    {
        private IItem _item;
        private int _cantidad;

        public Stack(IItem item)
        {
            _item = item;
            _cantidad = 1;
        }

        public bool EsIgual(IItem item)
        {
            return _item.EsIgual(item);
        }

        public void Agregar(IItem item)
        {
            if (!EsIgual(item))
                return;
            _cantidad++;
        }

        public void Sacar(IItem item)
        {
            if (!EsIgual(item) || _cantidad <= 0)
                return;
            _cantidad--;
        }

        public bool Vacio()
        {
            return _cantidad == 0;
        }
    }

    public interface IItem
    {
        public bool EsIgual(IItem item);
    }

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
