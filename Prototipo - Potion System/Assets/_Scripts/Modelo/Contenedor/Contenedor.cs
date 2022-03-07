using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private List<IIngrediente> _ingredientes;
        private ICapacidad _capacidad;
        private List<ICambiar> _modificadores;

        public Contenedor(ICapacidad capacidad, List<ICambiar> modificadores = null)
        {
            _ingredientes = new List<IIngrediente>();
            _capacidad = capacidad;
            _modificadores = (modificadores == null) ? new List<ICambiar>() : modificadores;
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
            _modificadores.ForEach(modificador => ingrediente.AgregarModificador(modificador));
            _ingredientes.Add(ingrediente);
            _capacidad.Agregar();
        }

        public void Mezclar(IIngrediente ingrediente1, IIngrediente ingrediente2)
        {
            if (_ingredientes.Contains(ingrediente1) && _ingredientes.Contains(ingrediente2))
                IIngrediente.Unirse(ingrediente1, ingrediente2);
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = Atributos.Nulo();
            _ingredientes.ForEach(ingredientes => atributos = ingredientes.Agregar(atributos));
            return atributos;
        }

        public Pocion ConsumirPocion()
        {
            if (_capacidad.Vacio())
                _ingredientes.Clear();
            _capacidad.Reducir();

            Atributos estado = CalcularEstado();
            return new Pocion(estado);
        }
    }
}
