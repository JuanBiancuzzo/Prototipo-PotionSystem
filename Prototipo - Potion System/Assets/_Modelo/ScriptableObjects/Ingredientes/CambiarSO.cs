using UnityEngine;

namespace ItIsNotOnlyMe
{
    public abstract class CambiarSO : ScriptableObject, ICambiar
    {
        public abstract void Cambiar(ICambiante cambiante);
        public abstract float Modificar(IIdentificador identificador, float valor);
    }
}
