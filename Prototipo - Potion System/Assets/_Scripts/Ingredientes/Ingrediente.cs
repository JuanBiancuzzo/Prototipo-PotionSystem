using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Ingrediente : IIngrediente
    {
        private List<ICambiar> _modificadores;
        private Atributos _atributosBase;

        public Ingrediente(Atributos atributosBase)
        {
            _modificadores = new List<ICambiar>();
            _atributosBase = atributosBase;
        }

        public Atributos Agregar(Atributos atributos)
        {
            List<Par> nuevosPares = new List<Par>();
            Atributos union = Atributos.UnionNula(_atributosBase, atributos);
            foreach (IIdentificador identificador in union.GetIdentificadores())
            {
                float nuevoValor = ObtenerValor(identificador);
                nuevosPares.Add(new Par(identificador, nuevoValor));
            }

            return Atributos.Sumar(atributos, new Atributos(nuevosPares));
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