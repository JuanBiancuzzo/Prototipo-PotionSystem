using NUnit.Framework;
using ItIsNotOnlyMe;

public class ProgresoPorcentualTest
{
    [Test]
    public void Test01ProgresoAlCrearseNoEstaFinalizado()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();
        Assert.IsFalse(progreso.Finalizado());
    }

    [Test]
    public void Test02PorcentajeInicialEsCero()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();
        Assert.AreEqual(0, progreso.Porcentaje());
    }

    [Test]
    public void Test03AlAvanzarDiezNoEstaFinalizadoYSuProgresoEsCeroPuntoUno()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();

        progreso.Avanzar(10);

        Assert.IsFalse(progreso.Finalizado());
        Assert.AreEqual(0.1f, progreso.Porcentaje());
    }

    [Test]
    public void Test04AlAvanzarCienEstaFinalizadoYSuProgresoEsUno()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();

        progreso.Avanzar(100);

        Assert.IsTrue(progreso.Finalizado());
        Assert.AreEqual(1f, progreso.Porcentaje());
    }

    [Test]
    public void Test05AlAvanzarCientoDiezEstaFinalizadoYSuProgresoEsUno()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();

        progreso.Avanzar(110);

        Assert.IsTrue(progreso.Finalizado());
        Assert.AreEqual(1f, progreso.Porcentaje());
    }

    [Test]
    public void Test06AlAvanzarDiezYDespuesAvanzarDiezElPorcentajeEsCeroPuntoUno()
    {
        IContadorDeProgreso progreso = new ProgresoPorcentual();

        progreso.Avanzar(10);
        Assert.AreEqual(0.1f, progreso.Porcentaje());

        progreso.Avanzar(10);
        Assert.AreEqual(0.1f, progreso.Porcentaje());
    }
}
