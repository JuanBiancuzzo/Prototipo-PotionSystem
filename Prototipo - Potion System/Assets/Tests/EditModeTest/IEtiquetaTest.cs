using System.Collections;
using System.Collections.Generic;
using ItIsNotOnlyMe;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IEtiquetaTest
{

    [Test]
    public void EtiquetaAumentarConConcentrarSeMultiplica()
    {
        Dimension dimension = ScriptableObject.CreateInstance<Dimension>();

        Eje[] ejes = new Eje[1];
        ejes[0] = new Eje(dimension);

        Espacio espacio = ScriptableObject.CreateInstance<Espacio>();
        espacio.Init(ejes, 0f);

        float valorAumentar = 5f, factorDisminuir = 1f, factorMultiplicar = 2f;

        IEtiqueta.Modificador[] modificadoresAumentar = new IEtiqueta.Modificador[1];
        modificadoresAumentar[0] = new IEtiqueta.Modificador(dimension, valorAumentar);

        IEtiqueta aumentar = new Aumentar(modificadoresAumentar, 0);

        IEtiqueta.Modificador[] modificadoresConcentrar = new IEtiqueta.Modificador[1];
        modificadoresConcentrar[0] = new IEtiqueta.Modificador(dimension, factorMultiplicar);

        IEtiqueta concentrar = new Concentrar(modificadoresConcentrar, factorDisminuir, aumentar);

        espacio.ModificarEspacio(concentrar);

        Assert.AreEqual(valorAumentar * factorMultiplicar, espacio.ValorPorDimension(dimension, out bool encontrado));
        Assert.IsTrue(encontrado);
    }

    [Test]
    public void EtiquetaAumentarConDosEjesYSeConcentraUna()
    {
        Dimension versorX = ScriptableObject.CreateInstance<Dimension>();
        Dimension versorY = ScriptableObject.CreateInstance<Dimension>();

        Eje[] ejes = new Eje[2];
        ejes[0] = new Eje(versorX);
        ejes[1] = new Eje(versorY);

        Espacio espacio = ScriptableObject.CreateInstance<Espacio>();
        espacio.Init(ejes, 0f);

        float valorAumentar = 5f, factorDisminuir = 0.5f, factorMultiplicar = 2f;

        IEtiqueta.Modificador[] modificadoresAumentar = new IEtiqueta.Modificador[1];
        modificadoresAumentar[0] = new IEtiqueta.Modificador(versorX, valorAumentar);

        IEtiqueta aumentar = new Aumentar(modificadoresAumentar, 0);

        IEtiqueta.Modificador[] modificadoresConcentrar = new IEtiqueta.Modificador[1];
        modificadoresConcentrar[0] = new IEtiqueta.Modificador(versorY, factorMultiplicar);

        IEtiqueta concentrar = new Concentrar(modificadoresConcentrar, factorDisminuir, aumentar);

        espacio.ModificarEspacio(concentrar);

        Assert.AreEqual(valorAumentar * factorDisminuir, espacio.ValorPorDimension(versorX, out bool encontrado));
        Assert.IsTrue(encontrado);

        Assert.AreEqual(0f, espacio.ValorPorDimension(versorY, out encontrado));
        Assert.IsTrue(encontrado);
    }

    [Test]
    public void EtiquetaAumentarDespuesInvertirlos()
    {
        Dimension versorX = ScriptableObject.CreateInstance<Dimension>();
        Dimension versorY = ScriptableObject.CreateInstance<Dimension>();

        Eje[] ejes = new Eje[2];
        ejes[0] = new Eje(versorX);
        ejes[1] = new Eje(versorY);

        Espacio espacio = ScriptableObject.CreateInstance<Espacio>();
        espacio.Init(ejes, 0f);

        float valorAumentar = 5f;

        IEtiqueta.Modificador[] modificadoresAumentar = new IEtiqueta.Modificador[1];
        modificadoresAumentar[0] = new IEtiqueta.Modificador(versorX, valorAumentar);

        IEtiqueta aumentar = new Aumentar(modificadoresAumentar, 0);

        IEtiqueta invertir = new Invertir(aumentar);

        espacio.ModificarEspacio(invertir);

        Assert.AreEqual(valorAumentar * (-1f), espacio.ValorPorDimension(versorX, out bool encontrado));
        Assert.IsTrue(encontrado);

        Assert.AreEqual(0f, espacio.ValorPorDimension(versorY, out encontrado));
        Assert.IsTrue(encontrado);
    }

    [Test]
    public void EtiquetaAumentarDespuesDosEjesYDespuesDiluir()
    {
        Dimension versorX = ScriptableObject.CreateInstance<Dimension>();
        Dimension versorY = ScriptableObject.CreateInstance<Dimension>();

        Eje[] ejes = new Eje[2];
        ejes[0] = new Eje(versorX);
        ejes[1] = new Eje(versorY);

        Espacio espacio = ScriptableObject.CreateInstance<Espacio>();
        espacio.Init(ejes, 0f);

        float valorAumentar = 5f, factorDisminuir = 0.5f;

        IEtiqueta.Modificador[] modificadoresAumentar = new IEtiqueta.Modificador[1];
        modificadoresAumentar[0] = new IEtiqueta.Modificador(versorX, valorAumentar);

        IEtiqueta aumentar = new Aumentar(modificadoresAumentar, 0);

        IEtiqueta diluir = new Diluir(factorDisminuir, aumentar);

        espacio.ModificarEspacio(diluir);

        Assert.AreEqual(valorAumentar * factorDisminuir, espacio.ValorPorDimension(versorX, out bool encontrado));
        Assert.IsTrue(encontrado);
    }
}
