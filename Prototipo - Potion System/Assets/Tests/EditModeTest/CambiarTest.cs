using NUnit.Framework;
using ItIsNotOnlyMe;
using System.Collections.Generic;

public class CambiarTest
{
    private class CambiantePrueba : ICambiante
    {
        private Atributos _atributoBase;
        private List<ICambiar> _modificadores;

        public CambiantePrueba(IIdentificador identificador, float valor)
        {
            _modificadores = new List<ICambiar>();
            _atributoBase = new Atributos(new List<Par> { new Par(identificador, valor) });
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _modificadores.Add(modificador);
        }

        public void SacarModificador(ICambiar modificador)
        {
            _modificadores.Remove(modificador);
        }

        public Atributos Modificar(Atributos atributos)
        {
            Atributos nuevo = _atributoBase;
            _modificadores.ForEach(modificador => nuevo = modificador.Modificar(nuevo));
            return Atributos.Sumar(nuevo, atributos);
        }
    }

    private IIdentificador _uno = new IdentificadorPrueba();
    private IIdentificador _dos = new IdentificadorPrueba();

    [Test]
    public void Test01CambiarSeCumpleYElValorPasaDeTresADos()
    {
        float valorCambiante = 3, valorCambio = 2;
        CambiantePrueba cambiante = new CambiantePrueba(_uno, valorCambiante);
        ICambiar cambiar = new CambiarSumarPrueba(valorCambio, _uno);

        cambiar.Cambiar(cambiante);

        Atributos respuesta = cambiante.Modificar(Atributos.Nulo());

        Assert.AreEqual(valorCambiante + valorCambio, respuesta.GetValor(_uno));
    }

    [Test]
    public void Test02CambiarVariaUnEjeQueNoTenia()
    {
        float valorCambiante = 3, valorCambio = 2;
        CambiantePrueba cambiante = new CambiantePrueba(_uno, valorCambiante);
        ICambiar cambiar = new CambiarSumarPrueba(valorCambio, _dos);

        cambiar.Cambiar(cambiante);

        Atributos respuesta = cambiante.Modificar(Atributos.Nulo());

        Assert.AreEqual(valorCambio, respuesta.GetValor(_dos));
    }
}
