using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public interface IElemento
    {
        public Energia EnergiaPotencial();

        public Carga CargaMagnetica();

        public List<IElemento> CrearEnlace(IElemento elemento, ref Energia energiaDelSistema);
    }
}