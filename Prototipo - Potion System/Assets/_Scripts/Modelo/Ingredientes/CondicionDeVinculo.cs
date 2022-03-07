namespace ItIsNotOnlyMe
{
    public class CondicionDeVinculo : ICondicionDeVinculo
    {
        private IRequisito _requisitoPropio, _requisitoOtro;
        private ICambiar _modificarPropio, _modificarOtro;

        public CondicionDeVinculo(IRequisito requisitoPropio,
                                  IRequisito requisitoOtro,
                                  ICambiar modificarPropio,
                                  ICambiar modificarOtro)
        {
            _requisitoPropio = requisitoPropio;
            _requisitoOtro = requisitoOtro;
            _modificarPropio = modificarPropio;
            _modificarOtro = modificarOtro;
        }

        public bool Evaluar(IDemandado propio, IDemandado otro)
        {
            return _requisitoPropio.Evaluar(propio) && _requisitoOtro.Evaluar(otro);
        }

        public void AgregarModificadores(ICambiante propio, ICambiante otro)
        {
            propio.AgregarModificador(_modificarPropio);
            otro.AgregarModificador(_modificarOtro);
        }

        public void SacarModificadores(ICambiante propio, ICambiante otro)
        {
            propio.SacarModificador(_modificarPropio);
            otro.SacarModificador(_modificarOtro);
        }
    }
}