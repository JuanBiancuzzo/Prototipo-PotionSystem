using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public interface IZona
    {
        
    }

    public class Zona : IZona
    {
        private IZona _zonaPadra;
        private List<IZona> _zonas;

        private IVista _vistaActual;

        public Zona(IZona zonaPare = null, List<IZona> zonas = null)
        {
            _zonaPadra = zonaPare;
            _zonas = (zonas != null) ? zonas : new List<IZona>();
        }
    }

    public interface IVista // la idea de una camara
    {
        public void Activar();

        public void Desactivar();
    }
}
