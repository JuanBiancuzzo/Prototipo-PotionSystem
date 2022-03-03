namespace ItIsNotOnlyMe
{
    public class Compuesto : IIngrediente
    {
        private IIngrediente _ingrediente1, _ingrediente2;

        public Compuesto(IIngrediente ingrediente1, IIngrediente ingrediente2)
        {
            _ingrediente1 = ingrediente1;
            _ingrediente2 = ingrediente2;

            _ingrediente1.ModificarOtro(_ingrediente2);
            _ingrediente2.ModificarOtro(_ingrediente1);
        }

        public Atributos Agregar(Atributos atributos)
        {
            Atributos sumaPrimera = _ingrediente1.Agregar(atributos);
            return _ingrediente2.Agregar(sumaPrimera);
        }
        public IIngrediente Unirse(IIngrediente ingrediente)
        {
            return PermiteUnirse() && ingrediente.PermiteUnirse() ? new Compuesto(this, ingrediente) : null;
        }

        public bool PermiteUnirse()
        {
            return _ingrediente1.PermiteUnirse() || _ingrediente2.PermiteUnirse();
        }

        public bool PermiteUnirseCon(IIngrediente ingrediente)
        {
            return _ingrediente1.PermiteUnirseCon(ingrediente) || _ingrediente2.PermiteUnirseCon(ingrediente);
        }

        public void ModificarOtro(IIngrediente ingrediente)
        {
            _ingrediente1.ModificarOtro(ingrediente);
            _ingrediente2.ModificarOtro(ingrediente);
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _ingrediente1.AgregarModificador(modificador);
            _ingrediente2.AgregarModificador(modificador);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            float valor = _ingrediente1.ObtenerValor(identificador);
            valor += _ingrediente2.ObtenerValor(identificador);
            return valor;
        }
    }
}