using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Ingrediente : IIngrediente
    {
        private List<IRequisito> _requisitosUnirse;
        private List<ICambiar> _modificaresOtro;

        private List<ICambiar> _modificadores;
        private Atributos _atributosBase;

        public Ingrediente(Atributos atributosBase,
                           List<IRequisito> requisitos = null,
                           List<ICambiar> modificadoresOtro = null)
        {
            _requisitosUnirse = (requisitos == null) ? new List<IRequisito>() : requisitos;
            _modificaresOtro = (modificadoresOtro == null) ? new List<ICambiar>() : modificadoresOtro;

            _modificadores = new List<ICambiar>();
            _atributosBase = atributosBase;
        }

        public Ingrediente(Atributos atributosBase,
                           List<ICambiar> modificadoresOtro,
                           List<IRequisito> requisitos = null)
            : this(atributosBase, requisitos, modificadoresOtro)
        {
        }

        public Atributos Agregar(Atributos atributos, float multiplicador = 1)
        {
            List<Par> nuevosPares = new List<Par>();
            Atributos union = Atributos.UnionNula(_atributosBase, atributos);
            foreach (IIdentificador identificador in union.GetIdentificadores())
            {
                float nuevoValor = ObtenerValor(identificador);
                nuevosPares.Add(new Par(identificador, nuevoValor));
            }

            Atributos multiplicado = Atributos.Multiplicar(new Atributos(nuevosPares), multiplicador);

            return Atributos.Sumar(atributos, multiplicado);
        }

        public IIngrediente Unirse(IIngrediente ingrediente)
        {
            return PermiteUnirse() && ingrediente.PermiteUnirse() ? new Compuesto(this, ingrediente) : null;
        }

        public bool PermiteUnirse()
        {
            return _requisitosUnirse.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public void ModificarOtro(IIngrediente ingrediente)
        {
            _modificaresOtro.ForEach(modificador => ingrediente.AgregarModificador(modificador));
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _modificadores.Add(modificador);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            float valor = _atributosBase.GetValor(identificador);
            _modificadores.ForEach(cambiar => valor = cambiar.Modificar(identificador, valor));
            return valor;
        }
    }
}