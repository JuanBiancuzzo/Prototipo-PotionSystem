using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    // los ingredientes y las pociones son variaciones de contenedor
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

        public bool AgregarElemento(IElemento elemento)
        {
            if (_capacidad.Lleno())
                return false;

            _modificadores.ForEach(modificador => elemento.AgregarModificador(modificador));
            _elementos.Add(elemento);
            _capacidad.Agregar();
            return true;
        }

        public void Mezclar(IElemento elemento1, IElemento elemento2)
        {
            if (_elementos.Contains(elemento1) && _elementos.Contains(elemento2))
                IElemento.Unirse(elemento1, elemento2);
        }

        public Vector CalcularEstado()
        {
            Vector atributos = Vector.VectorNulo();
            _elementos.ForEach(elemento => atributos = elemento.Agregar(atributos));
            return atributos;
        }

        public void Transferir(IContenedor contenedor)
        {
            while (!contenedor.Lleno() && _capacidad.Vacio())
            {
                IElemento elemento = _elementos[0];
                contenedor.AgregarElemento(elemento);

                _capacidad.Reducir();
                _elementos.RemoveAt(0);
            }
        }

        public IResultado ConseguirResultado()
        {
            if (_capacidad.Vacio())
                _elementos.Clear();
            _capacidad.Reducir();

            Vector estado = CalcularEstado();
            return new Resultado(estado);
        }

        public bool Lleno()
        {
            return _capacidad.Lleno();
        }
    }
}
