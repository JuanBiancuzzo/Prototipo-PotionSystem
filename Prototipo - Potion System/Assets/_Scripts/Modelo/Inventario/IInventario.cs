namespace ItIsNotOnlyMe.Inventario
{
    public interface IInventario
    {
        public bool Agregar(IItem item);

        public bool Sacar(IItem item);
    }
}
