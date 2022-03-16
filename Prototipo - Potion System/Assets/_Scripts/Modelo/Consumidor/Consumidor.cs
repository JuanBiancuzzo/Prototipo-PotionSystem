using System.Collections.Generic;
using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public class Consumidor : IConsumidor
    {
        private Vector _estadoInicial;
        private List<IContenedor> _pociones;
        private List<IRequisito> _requisitosSobrevivir, _requisitosSatisfaccion;

        public Consumidor(Vector estadoInicial,
                          List<IRequisito> requisitosSobrevivir = null,
                          List<IRequisito> requisitosSatisfaccion = null)
        {
            _estadoInicial = estadoInicial;

            if (requisitosSobrevivir == null)
                requisitosSobrevivir = new List<IRequisito>();
            _requisitosSobrevivir = requisitosSobrevivir;

            if (requisitosSatisfaccion == null)
                requisitosSatisfaccion = new List<IRequisito>();
            _requisitosSatisfaccion = requisitosSatisfaccion;

            _pociones = new List<IContenedor>();
        }

        public void Consumir(IContenedor pocion)
        {
            _pociones.Add(pocion);
        }

        public bool EnCondicionesParaSeguir()
        {
            return _requisitosSobrevivir.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public bool Evaluacion()
        {
            return _requisitosSatisfaccion.TrueForAll(requisito => requisito.Evaluar(this));
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            Vector estado = EstadoModificado();
            return estado.ProductoInterno(new Vector(new Componente(identificador, 1)));
        }

        private Vector EstadoModificado()
        {
            Vector resultado = _estadoInicial;
            _pociones.ForEach(pocion => resultado = resultado.Sumar(pocion.CalcularEstado()));
            return resultado;
        }
    }
}
