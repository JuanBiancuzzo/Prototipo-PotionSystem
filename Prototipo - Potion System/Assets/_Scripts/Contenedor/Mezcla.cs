using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Mezcla
    {
        private Atributos _estado;
        //private List<ProcesoIngrediente> _procesos;
        //private IFactoryContador _fabricaContador;

        private List<IIngrediente> _ingredientes;

        public Mezcla(Atributos estado)
        {
            _estado = estado;
            _ingredientes = new List<IIngrediente>();
        }

        /*public Mezcla(Atributos estadoIncial, IFactoryContador factoryContador)
        {
            _procesos = new List<ProcesoIngrediente>();
            _estado = estadoIncial;
            _fabricaContador = factoryContador;
        }*/

        public void Agregar(IIngrediente ingrediente)
        {
            //IContadorDeProgreso contador = _fabricaContador.CrearContador();
            //_procesos.Add(new ProcesoIngrediente(ingrediente, contador));
            _ingredientes.Add(ingrediente);
        }

        /*public void Avanzar(float dt)
        {
            foreach (ProcesoIngrediente proceso in _procesos)
                if (!proceso.Finalizado())
                    proceso.Avanzar(dt);
        }*/

        public void Mezclar()
        {
            
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = _estado;
            /*List<ProcesoIngrediente> procesosTerminados = new List<ProcesoIngrediente>();

            foreach (ProcesoIngrediente proceso in _procesos)
            {
                float porcentaje = proceso.Porcentaje();
                atributos = proceso.Agregar(atributos, porcentaje);

                if (proceso.Finalizado())
                    procesosTerminados.Add(proceso);
            }

            procesosTerminados.ForEach(proceso => _procesos.Remove(proceso));*/
            _ingredientes.ForEach(ingredientes => atributos = ingredientes.Agregar(atributos));
            return atributos;
        }

        public void Finalizar()
        {
            //_procesos.Clear();
            _ingredientes.Clear();
        }
    }
}
