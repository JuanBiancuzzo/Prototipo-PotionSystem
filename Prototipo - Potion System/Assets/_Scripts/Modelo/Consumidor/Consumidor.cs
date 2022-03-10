using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Consumidor : IConsumidor
    {
        private Vector _estadoObjetivo, _estadoInicial;
        private List<IRequisito> _requisitoParaSobrevivir;
        private List<IContenedor> _consumibles;

        public Consumidor (Vector estadoInicial, Vector estadoObjetivo, List<IRequisito> requisitos = null)
        {
            _estadoInicial = estadoInicial;
            _estadoObjetivo = estadoObjetivo;
            _requisitoParaSobrevivir = (requisitos == null) ? new List<IRequisito>() : requisitos;
            _consumibles = new List<IContenedor>();
        }

        public void Consumir(IContenedor pocion)
        {
            if (!EnCondicionesParaSeguir())
                return;
            _consumibles.Add(pocion);
        }

        public bool EnCondicionesParaSeguir()
        {
            return _requisitoParaSobrevivir.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public float Evaluacion()
        {
            Vector estadoActual = EstadoActual();
            float distancia = MathfVectores.Distancia(estadoActual, _estadoObjetivo);
            float similitud = MathfVectores.Similitud(estadoActual, _estadoObjetivo);
            float multiplicidad = MathfVectores.Multiplicdad(estadoActual, _estadoObjetivo);

            // ecuacion para mostrar cuantos puntos deberia tener
            return -distancia + similitud - (multiplicidad - 1);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            Vector estadoActual = EstadoActual();
            return estadoActual.ProductoInterno(new Vector(new Componente(identificador, 1)));
        }

        private Vector EstadoActual()
        {
            Vector estadoActual = _estadoInicial;
            _consumibles.ForEach(consumible => estadoActual = estadoActual.Sumar(consumible.CalcularEstado()));
            return estadoActual;
        }
    }
}
