using UnityEngine;

namespace ItIsNotOnlyMe
{
    public abstract class RequisitoSO : ScriptableObject, IRequisito
    {
        public abstract float ConseguirValor(IDemandado demandado, IIdentificador identificador);
        public abstract bool Evaluar(IDemandado demandado);
    }
}
