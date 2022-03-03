using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private IMezcla _mezcla;

        public Contenedor(IMezcla mezcla)
        {
            _mezcla = mezcla;
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
            _mezcla.Agregar(ingrediente);
        }

        public void Mezclar()
        {
            _mezcla.Mezclar();
        }

        public Pocion Finalizar()
        {
            Atributos estado = _mezcla.CalcularEstado();
            _mezcla.Finalizar();
            return new Pocion(estado);
        }
    }
}
