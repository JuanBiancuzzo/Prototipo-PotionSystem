using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private static int _minimoCapacidad;

        private Atributos _estado;
        private List<IIngrediente> _ingredientes;
        private ICapacidad _capacidad;

        public Contenedor(Atributos estadoInicial, ICapacidad capacidad)
        {
            _estado = estadoInicial;
            _ingredientes = new List<IIngrediente>();
            _capacidad = capacidad;
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
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
            Atributos atributos = _estado;
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
