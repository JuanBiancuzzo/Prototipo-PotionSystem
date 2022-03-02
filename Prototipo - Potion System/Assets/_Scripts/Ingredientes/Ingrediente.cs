using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Ingrediente : IIngrediente
    {
        private List<ICombinacionRequisitos> _requisitos;
        private List<ICambiar> _modificaresOtro;

        private List<ICambiar> _modificadores;
        private Atributos _atributosBase;

        public Ingrediente(Atributos atributosBase,
                           List<ICombinacionRequisitos> requisitos = null,
                           List<ICambiar> modificadoresOtro = null)
        {
            _requisitos = (requisitos == null) ? new List<ICombinacionRequisitos>() : requisitos;
            _modificaresOtro = (modificadoresOtro == null) ? new List<ICambiar>() : modificadoresOtro;

            _modificadores = new List<ICambiar>();
            _atributosBase = atributosBase;
        }

        public Ingrediente(Atributos atributosBase,
                           List<ICambiar> modificadoresOtro,
                           List<ICombinacionRequisitos> requisitos = null)
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
            if (!(PermiteUnirse() && ingrediente.PermiteUnirse()))
                return null;
            return PermiteUnirseCon(ingrediente) && ingrediente.PermiteUnirseCon(this) ? new Compuesto(this, ingrediente) : null;
        }

        public bool PermiteUnirse()
        {
            bool permite = false;
            foreach (ParRequisito par in _requisitos)
                permite |= par.EvaluarPropio(this);
            return _requisitos.Count > 0 ? permite : true;
        }

        public bool PermiteUnirseCon(IIngrediente ingrediente)
        {
            bool permite = false;
            foreach (ParRequisito par in _requisitos)
                permite |= (par.EvaluarPropio(this) && par.EvaluarOtro(ingrediente));
            return _requisitos.Count > 0 ? permite : true;
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