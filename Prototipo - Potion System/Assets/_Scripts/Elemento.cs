using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Elemento : IElemento
    {
        private Nucleo _nucleo;
        private CapaElectronica _capaElectronica;

        public Elemento(int numeroAtomico)
        {
            
        }

        public Energia EnergiaPotencial()
        {
            return _capaElectronica.EnergiaPotencial();
        }

        public Carga CargaMagnetica()
        {
            Carga cargaNucleo = _nucleo.CargaMagnetica();
            Carga cargaElectrones = _capaElectronica.CargaMagnetica();

            return Carga.Sumar(cargaNucleo, cargaElectrones);
        }

        public List<IElemento> CrearEnlace(IElemento elemento, ref Energia energiaDelSistema)
        {
            List<IElemento> elementos = new List<IElemento>();

            elementos.Add(this);
            elementos.Add(elemento);

            return elementos;
        }
    }
}