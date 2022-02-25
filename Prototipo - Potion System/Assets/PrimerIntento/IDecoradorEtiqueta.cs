using UnityEngine;

namespace ItIsNotOnlyMe
{
    public abstract class IDecoradorEtiqueta : IEtiqueta
    {

        [SerializeField] protected IEtiqueta _etiqueta;

        public IDecoradorEtiqueta(IEtiqueta etiqueta)
        {
            _etiqueta = etiqueta;
        }
        
    }
}
