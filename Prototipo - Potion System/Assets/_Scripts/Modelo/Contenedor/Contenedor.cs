using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private List<IElemento> _elementos;
        private ICapacidad _capacidad;
        private List<ICambiar> _modificadores;

        public Contenedor(ICapacidad capacidad, List<ICambiar> modificadores = null)
        {
            _elementos = new List<IElemento>();
            _capacidad = capacidad;
            _modificadores = (modificadores == null) ? new List<ICambiar>() : modificadores;
        }

        public void AgregarIngrediente(IElemento elemento)
        {
            _modificadores.ForEach(modificador => elemento.AgregarModificador(modificador));
            _elementos.Add(elemento);
            _capacidad.Agregar();
        }

        public void Mezclar(IElemento elemento1, IElemento elemento2)
        {
            if (_elementos.Contains(elemento1) && _elementos.Contains(elemento2))
                IElemento.Unirse(elemento1, elemento2);
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = Atributos.Nulo();
            _elementos.ForEach(elemento => atributos = elemento.Agregar(atributos));
            return atributos;
        }

        public Pocion ConsumirPocion()
        {
            if (_capacidad.Vacio())
                _elementos.Clear();
            _capacidad.Reducir();

            Atributos estado = CalcularEstado();
            return new Pocion(estado);
        }
    }
}
