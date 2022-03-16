namespace ItIsNotOnlyMe.Inventario
{
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
}
