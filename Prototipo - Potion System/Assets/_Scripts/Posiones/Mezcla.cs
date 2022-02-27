using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Mezcla
    {
        private Atributos _estado;
        private List<IIngrediente> _ingredientes;

        public Mezcla(Atributos estadoIncial)
        {
            _estado = estadoIncial;
        }

        public void Agregar(IIngrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
        }

        public Posion Finalizar()
        {
            return new Posion(CalcularEstado());
        }

        private Atributos CalcularEstado()
        {
            return _estado;
        }
    }
}
