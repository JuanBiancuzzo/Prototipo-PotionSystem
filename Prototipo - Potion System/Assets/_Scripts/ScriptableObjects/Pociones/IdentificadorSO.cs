using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Identificador", menuName = "Posiones/Identificador")]
    public class IdentificadorSO : ScriptableObject, IIdentificador
    {
        private static int _contador = 0;
        private int _id;

        private void Awake()
        {
            _id = _contador;
            _contador++;
        }

        public bool EsIgual(IIdentificador identificador)
        {
            return _id == identificador.GetID();
        }

        public int GetID()
        {
            return _id;   
        }
    }
}
