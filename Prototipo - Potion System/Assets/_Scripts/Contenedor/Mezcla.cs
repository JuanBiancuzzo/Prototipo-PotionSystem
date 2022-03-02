using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Mezcla
    {
        private Atributos _estado;
        private List<ProcesoIngrediente> _procesos;
        private IFactoryContador _fabricaContador;

        public Mezcla(Atributos estadoIncial, IFactoryContador factoryContador)
        {
            _procesos = new List<ProcesoIngrediente>();
            _estado = estadoIncial;
            _fabricaContador = factoryContador;
        }

        public void Agregar(IIngrediente ingrediente)
        {
            IContadorDeProgreso contador = _fabricaContador.CrearContador();
            _procesos.Add(new ProcesoIngrediente(ingrediente, contador));
        }

        public void Avanzar(float dt)
        {
            foreach (ProcesoIngrediente proceso in _procesos)
                if (!proceso.Finalizado())
                    proceso.Avanzar(dt);
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = _estado;
            _procesos.ForEach(p => atributos = p.Agregar(atributos, p.Porcentaje()));
            return atributos;
        }

        public Posion Finalizar()
        {
            Posion posion = new Posion(CalcularEstado());

            _procesos.Clear();

            return posion;
        }
    }
}
