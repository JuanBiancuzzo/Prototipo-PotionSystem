namespace ItIsNotOnlyMe
{
    public class ParRequisito : ICombinacionRequisitos
    {
        private IRequisito _requisitoPropio, _requisitoOtro;

        public ParRequisito(IRequisito requisitoPropio, IRequisito requisitoOtro)
        {
            _requisitoPropio = requisitoPropio;
            _requisitoOtro = requisitoOtro;
        }

        public bool EvaluarPropio(IDemandado propio)
        {
            return _requisitoPropio.Evaluar(propio);
        }

        public bool EvaluarOtro(IDemandado otro)
        {
            return _requisitoOtro.Evaluar(otro);
        }
    }
}