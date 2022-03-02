using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class ParRequisitoSO : ScriptableObject, ICombinacionRequisitos
    {
        public RequisitoSO _requisitoPropio, _requisitoOtro;

        private ICombinacionRequisitos _parBase;
        private ICombinacionRequisitos _parRequisito
        {
            get
            {
                if (_parBase == null)
                    _parBase = new ParRequisito(_requisitoPropio, _requisitoOtro);
                return _parBase;
            }
        }

        public bool EvaluarPropio(IDemandado propio)
        {
            return _parRequisito.EvaluarPropio(propio);
        }

        public bool EvaluarOtro(IDemandado otro)
        {
            return _parRequisito.EvaluarOtro(otro);
        }
    }
}
