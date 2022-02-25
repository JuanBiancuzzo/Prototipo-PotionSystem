namespace ItIsNotOnlyMe
{
    public class Proton
    {
        static int cargaEstandar = 1;
        private int _carga;

        public Proton()
        {
            _carga = cargaEstandar;
        }

        public Proton(int carga)
        {
            _carga = carga;
        }

        public Carga CargaMagnetica()
        {
            return new Carga(_carga);
        }
    }
}