using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public abstract class IAtomo : ScriptableObject, IElemento
    {
        protected virtual IElemento _elemento { get; }

        public Energia EnergiaPotencial()
        {
            return _elemento.EnergiaPotencial();
        }

        public Carga CargaMagnetica()
        {
            return _elemento.CargaMagnetica();
        }

        public List<IElemento> CrearEnlace(IElemento elemento, ref Energia energiaDelSistema)
        {
            return _elemento.CrearEnlace(elemento, ref energiaDelSistema);
        }
    }
}