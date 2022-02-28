using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class IngredienteTest
{
    private class Identificador : IIdentificador
    {
        private static int _contador = 0;
        private int _id;

        public Identificador()
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
        _vida = new Identificador();
        _temp = new Identificador();
        _vel = new Identificador();

        atributosNulo = new Atributos(new List<Par>
        {
            new Par(_vida, 0f), new Par(_temp, 0f), new Par(_vel, 0f)
        });
    }

    [Test]
    public void IngredienteConLosRequisitosEsEvaluadoPositivo()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _vida);

        Assert.IsTrue(requisito.Evaluar(ingrediente));
    }

    [Test]
    public void IngredienteSinLosRequisitosEsEvaluadoNegativo()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayor(valorMinimo, _temp);

        Assert.IsFalse(requisito.Evaluar(ingrediente));
    }

    [Test]
    public void IngredienteEsModificadoSumandoleDosALaDimensionVida()
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
    public void IngredienteEsModificadoSumandoleDosALaDimensionVelocidadQueNoTiene()
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
}
