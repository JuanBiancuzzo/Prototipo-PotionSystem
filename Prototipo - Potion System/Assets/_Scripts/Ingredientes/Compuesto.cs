﻿namespace ItIsNotOnlyMe
{
    public class Compuesto : IIngrediente
    {
        private IRequisito _reglas;
        private IIntercambio _guias;
        private IIngrediente _ingrediente1, _ingrediente2;

        public Compuesto(IIngrediente ingrediente1, IIngrediente ingrediente2)
        {
            _ingrediente1 = ingrediente1;
            _ingrediente2 = ingrediente2;

            _reglas = _ingrediente1.UnirReglas(_ingrediente2);
            _guias = _ingrediente1.UnirGuias(_ingrediente2);
        }

        public Atributos Agregar(Atributos atributos)
        {
            Atributos primero = _ingrediente1.Agregar(atributos);
            return _ingrediente2.Agregar(primero);
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