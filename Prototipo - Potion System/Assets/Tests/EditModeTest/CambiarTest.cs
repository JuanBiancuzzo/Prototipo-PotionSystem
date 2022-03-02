using NUnit.Framework;
using ItIsNotOnlyMe;
using System.Collections.Generic;

public class CambiarTest
{
    private class IdentificadorPrueba : IIdentificador
    {
        private static int _contador = 0;
        private int _id;

        public IdentificadorPrueba()
        {
            _id = _contador;
            _contador++;
        }

        public int GetID()
        {
            return _id;
        }

        public bool EsIgual(IIdentificador identificador)
        {
            return _id == identificador.GetID();
        }
    }

    private class CambiantePrueba : ICambiante
    {
        private IIdentificador _identificador;
        private float _valor, _valorNulo;
        private List<ICambiar> _cambiantes;

        public CambiantePrueba(IIdentificador identificador, float valor, float valorNulo)
        {
            _identificador = identificador;
            _valor = valor;
            _valorNulo = valorNulo;
            _cambiantes = new List<ICambiar>();
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _cambiantes.Add(modificador);
        }

        public float GetValor(IIdentificador identificador)
        {
            float valor = _identificador.EsIgual(identificador) ? _valor : _valorNulo;
            _cambiantes.ForEach(cambiar => valor = cambiar.Modificar(identificador, valor));
            return valor;
        }
    }

    private class CambiarSumar : ICambiar
    {
        private float _valorSumar;
        private IIdentificador _identificador;

        public CambiarSumar(float valorSumar, IIdentificador identificador)
        {
            _valorSumar = valorSumar;
            _identificador = identificador;
        }

        public void Cambiar(ICambiante cambiante)
        {
            cambiante.AgregarModificador(this);
        }

        public float Modificar(IIdentificador identificador, float valor)
        {
            if (_identificador.EsIgual(identificador))
                return valor + _valorSumar;
            return _valorSumar;
        }
    }

    private IIdentificador _uno = new IdentificadorPrueba();
    private IIdentificador _dos = new IdentificadorPrueba();

    [Test]
    public void Test01CambiarSeCumpleYElValorPasaDeTresADos()
    {
        float valorCambiante = 3, valorNulo = 0, valorCambio = 2;
        CambiantePrueba cambiante = new CambiantePrueba(_uno, valorCambiante, valorNulo);
        ICambiar cambiar = new CambiarSumar(valorCambio, _uno);

        cambiar.Cambiar(cambiante);

        Assert.AreEqual(valorCambiante + valorCambio, cambiante.GetValor(_uno));
    }

    [Test]
    public void Test02CambiarVariaUnEjeQueNoTenia()
    {
        float valorCambiante = 3, valorNulo = 0, valorCambio = 2;
        CambiantePrueba cambiante = new CambiantePrueba(_uno, valorCambiante, valorNulo);
        ICambiar cambiar = new CambiarSumar(valorCambio, _dos);

        cambiar.Cambiar(cambiante);

        Assert.AreEqual(valorNulo + valorCambio, cambiante.GetValor(_dos));
    }
}
