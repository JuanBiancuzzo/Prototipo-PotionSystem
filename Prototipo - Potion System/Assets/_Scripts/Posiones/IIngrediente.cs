namespace ItIsNotOnlyMe
{
    public interface IIngrediente
    {
        public bool Vacio();

        public void Agregar(IContenedor contenedor);

        public void Modificar(ref Atributos atributos);

        public void Modificar(ref Propiedades propiedades);
    }

    public interface IContenedor
    {
        public void ModificarPropiedadesDeLaPosion(IIngrediente ingrediente);

        public void ModificarAtributosDelContenedor(IIngrediente ingrediente);
    }

    public class Ingrediente : IIngrediente
    {
        private int _cantidad, _division;

        public bool Vacio()
        {
            return _cantidad == 0;
        }

        public void Agregar(IContenedor contenedor)
        {
            contenedor.ModificarAtributosDelContenedor(this);
            contenedor.ModificarPropiedadesDeLaPosion(this);

            _cantidad -= _division;
            if (_cantidad <= 0)
                _cantidad = 0;
        }

        public void Modificar(ref Atributos atributos)
        {
            throw new System.NotImplementedException();
        }

        public void Modificar(ref Propiedades propiedades)
        {
            throw new System.NotImplementedException();
        }
    }
}
