using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private Atributos _estado;
        private List<IIngrediente> _ingredientes;

        public Contenedor(Atributos estadoInicial)
        {
            _estado = estadoInicial;
            _ingredientes = new List<IIngrediente>();
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
        }

        public void Mezclar(IIngrediente ingrediente1, IIngrediente ingrediente2)
        {
            if (!_ingredientes.Exists(i => i == ingrediente1 || i == ingrediente2))
                return;

            IIngrediente.Unirse(ingrediente1, ingrediente2);
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = _estado;
            _ingredientes.ForEach(ingredientes => atributos = ingredientes.Agregar(atributos));
            return atributos;
        }

        public Pocion Finalizar()
        {
            Atributos estado = CalcularEstado();
            _ingredientes.Clear();
            return new Pocion(estado);
        }
    }
}
