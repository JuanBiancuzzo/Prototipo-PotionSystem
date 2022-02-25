using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Electron
    {
        static int cargaEstandar = -1;
        private int _carga;

        public Electron()
        {
            _carga = cargaEstandar;
        }

        public Electron(int carga)
        {
            _carga = carga;
        }

        public Carga CargaMagnetica()
        {
            return new Carga(_carga);
        }
    }
}