using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class ContenedorTest
{
    private Mezcla _mezcla; 
    private Atributos _estadoInicial;
    private IIdentificador _vida, _temp, _vel;

    public ContenedorTest()
    {

        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();

        _estadoInicial = new Atributos(new List<Par>
        {
            new Par(_vida, 1f), new Par(_temp, 1f), new Par(_vel, 1f)
        });
        _mezcla = new Mezcla(_estadoInicial);
    }

    [Test]
    public void UnContenedorSinIngredientesDaUnaPosionIgualAlEstadoInicial()
    {
        IContenedor contenedor = new Contenedor(_mezcla);
        Posion posionEsperada = new Posion(_estadoInicial);

        Posion posionResultado = contenedor.Finalizar();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(posionEsperada.Similitud(posionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(posionEsperada.Multiplicidad(posionResultado), Is.EqualTo(1f).Using(comparador));
    }
}
