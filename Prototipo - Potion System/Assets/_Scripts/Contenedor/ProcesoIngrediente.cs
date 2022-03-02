using System;

namespace ItIsNotOnlyMe
{
    public struct ProcesoIngrediente
    {
        private IIngrediente _ingrediente;
        private IContadorDeProgreso _contador;

        public ProcesoIngrediente(IIngrediente ingrediente, IContadorDeProgreso contador)
        {
            _ingrediente = ingrediente;
            _contador = contador;
        }

        public bool Finalizado()
        {
            return _contador.Finalizado();
        }

        public void Avanzar(float dt)
        {
            _contador.Avanzar(dt);
        }

        public float Porcentaje()
        {
            return _contador.Porcentaje();
        }

        public Atributos Agregar(Atributos atributos, float multiplicador = 1)
        {
            return _ingrediente.Agregar(atributos, multiplicador);
        }

        public bool PermiteUnirse()
        {
            return _ingrediente.PermiteUnirse();
        }

        public bool PermiteUnirseCon(ProcesoIngrediente proceso)
        {
            return _ingrediente.PermiteUnirseCon(proceso._ingrediente);
        }

        public Tuple<ProcesoIngrediente, ProcesoIngrediente> Unir(ProcesoIngrediente procesoOtro)
        {
            if (!(PermiteUnirse() && PermiteUnirseCon(procesoOtro) && procesoOtro.PermiteUnirse() && procesoOtro.PermiteUnirseCon(this)))
                return null;

            return null;
        }
    }
}
