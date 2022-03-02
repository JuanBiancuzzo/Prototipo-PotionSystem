using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class IngredienteTest
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
            return valor;
        }
    }

    private class CambiarMultiplicar : ICambiar
    {
        private float _valorSumar;
        private IIdentificador _identificador;

        public CambiarMultiplicar(float valorSumar, IIdentificador identificador)
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
                return valor * _valorSumar;
            return valor;
        }
    }

    private class RequisitoMayor : IRequisito
    {
        private float _valorMinimo;
        private IIdentificador _identificador;

        public RequisitoMayor(float valorMinimo, IIdentificador identificador)
        {
            _valorMinimo = valorMinimo;
            _identificador = identificador;
        }

        public float ConseguirValor(IDemandado ingrediente, IIdentificador identificador)
        {
            return ingrediente.ObtenerValor(identificador);
        }

        public bool Evaluar(IDemandado ingrediente)
        {
            float valor = ConseguirValor(ingrediente, _identificador);
            return valor > _valorMinimo;
        }
    }

    private IIdentificador _vida, _temp, _vel;
    private Atributos atributosNulo;

    public IngredienteTest()
    {
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();

        atributosNulo = new Atributos(new List<Par>
        {
            new Par(_vida, 0f), new Par(_temp, 0f), new Par(_vel, 0f)
        });
    }

    [Test]
    public void Test01IngredienteSinNingunRequisitoNecesarioEsEvaluadoPositivo()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        Assert.IsTrue(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test02IngredienteConLosRequisitosEsEvaluadoPositivo()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _vida);

        List<IRequisito> requisitos = new List<IRequisito> { requisito };

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase, requisitos);

        Assert.IsTrue(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test03IngredienteSinLosRequisitosEsEvaluadoNegativo()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _temp);

        List<IRequisito> requisitos = new List<IRequisito> { requisito };

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase, requisitos);

        Assert.IsFalse(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test04IngredienteEsModificadoSumandoleDosALaDimensionVida()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorASumar = 2f;
        ICambiar cambiar = new CambiarSumar(valorASumar, _vida);

        cambiar.Cambiar(ingrediente);

        Atributos resultado = ingrediente.Agregar(atributosNulo);

        Assert.AreEqual(valorVida + valorASumar, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test05IngredienteEsModificadoSumandoleDosALaDimensionVelocidadQueNoTiene()
    {
        float valorVida = 5f, valorTemp = 3f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorASumar = 2f;
        ICambiar cambiar = new CambiarSumar(valorASumar, _vel);

        cambiar.Cambiar(ingrediente);

        Atributos resultado = ingrediente.Agregar(atributosNulo);

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorASumar, resultado.GetValor(_vel));
    }

    [Test]
    public void Test06CuandoSeJuntanDosIngredientesSinModificacionesYSinCondicionesElResultadoEsLaSumaDeAmbos()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreNotEqual(null, compuesto);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test07ElPrimerIngredienteNoEstaEnCondicionesDeUnirse()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _temp);

        List<IRequisito> requisitos = new List<IRequisito> { requisito };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, requisitos);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        Assert.IsFalse(ingrediente1.PermiteUnirse());
        Assert.IsTrue(ingrediente2.PermiteUnirse());

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreEqual(null, compuesto);
    }

    [Test]
    public void Test08ElSegundoIngredienteNoEstaEnCondicionesDeUnirse()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _temp);

        List<IRequisito> requisitos = new List<IRequisito> { requisito };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, requisitos);

        Assert.IsTrue(ingrediente1.PermiteUnirse());
        Assert.IsFalse(ingrediente2.PermiteUnirse());

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreEqual(null, compuesto);
    }

    [Test]
    public void Test09ElPrimeroTieneModificacionesParaElSegundoEntoncesElCompuestoEsElPrimeroMasElSegundoModificado()
    {
        float valorASumar = 2f;
        ICambiar cambiar = new CambiarMultiplicar(valorASumar, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { cambiar };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2 * valorASumar, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test10ElSegundoTieneModificacionesParaElPrimeroEntoncesElCompuestoEsElPrimeroModificadoMasElSegundo()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorASumar = 2f;
        ICambiar cambiar = new CambiarMultiplicar(valorASumar, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { cambiar };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 * valorASumar + valorVida2, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test11LosDosIngredientesTieneModificadoresEntoncesElCompuestoEsLaSumaModificada()
    {
        float valorASumar1 = 3f;
        List<ICambiar> modificadores1 = new List<ICambiar> { new CambiarMultiplicar(valorASumar1, _vida) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores1);

        float valorASumar2 = 4f;
        List<ICambiar> modificadores2 = new List<ICambiar> { new CambiarMultiplicar(valorASumar2, _temp) };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2 * valorASumar1, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 * valorASumar2 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }
}
