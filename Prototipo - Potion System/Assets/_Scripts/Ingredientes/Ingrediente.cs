namespace ItIsNotOnlyMe
{
    public class Ingrediente : IIngrediente
    {
        private IRequisito _reglas;
        private IIntercambio _guias;
        private Atributos _atributos;

        public Ingrediente(IRequisito reglas, IIntercambio guias, Atributos atributos)
        {
            _reglas = reglas;
            _guias = guias;
            _atributos = atributos;
        }

        public Atributos Agregar(Atributos atributos)
        {
            return Atributos.Sumar(_atributos, atributos);
        }

        public IIngrediente CrearCombinacion(IIngrediente otro)
        {
            if (!PermiteUnirse(otro))
                return null;

            AplicarIntercambio(otro);
            otro.AplicarIntercambio(this);

            return new Compuesto(this, otro);
        }

        public IRequisito UnirReglas(IRequisito requisito)
        {
            return _reglas.CombinacionNueva(requisito);
        }

        public IRequisito UnirReglas(IIngrediente ingrediente)
        {
            return ingrediente.UnirReglas(_reglas);
        }

        public IIntercambio UnirGuias(IIntercambio intercambio)
        {
            return _guias.CombinacionNueva(intercambio);
        }

        public IIntercambio UnirGuias(IIngrediente ingrediente)
        {
            return ingrediente.UnirGuias(_guias);
        }

        public void AplicarIntercambio(IIngrediente otro)
        {
            _guias.Intercambiar(this, otro);
        }

        public bool PermiteUnirse(IIngrediente otro)
        {
            return _reglas.Permitido(this, otro);
        }
    }
}