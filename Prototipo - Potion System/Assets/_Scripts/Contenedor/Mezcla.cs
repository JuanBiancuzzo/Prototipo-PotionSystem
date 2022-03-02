using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Mezcla
    {
        private Atributos _estado;

        private List<IIngrediente> _ingredientes;

        public Mezcla(Atributos estado)
        {
            _estado = estado;
            _ingredientes = new List<IIngrediente>();
        }

        public void Agregar(IIngrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
        }

        public void Mezclar()
        {
            
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = _estado;
            _ingredientes.ForEach(ingredientes => atributos = ingredientes.Agregar(atributos));
            return atributos;
        }

        public void Finalizar()
        {
            _ingredientes.Clear();
        }
    }
}
