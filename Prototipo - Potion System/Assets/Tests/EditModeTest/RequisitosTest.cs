using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public partial class RequisitosTest
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

    private class IngredientePrueba : IIngrediente
    {
        private IIdentificador _identificador;
        private float _valor, _valorNulo;

        public IngredientePrueba(IIdentificador identificador, float valor, float valorNulo)
        {
            _identificador = identificador;
            _valor = valor;
            _valorNulo = valorNulo;
        }

        public Atributos Agregar(Atributos atributos)
        {
            throw new System.NotImplementedException();
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            return _identificador.EsIgual(identificador) ? _valor : _valorNulo;
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

        public float ConseguirValor(IIngrediente ingrediente, IIdentificador identificador)
        {
            return ingrediente.ObtenerValor(identificador);
        }

        public bool Evaluar(IIngrediente ingrediente)
        {
            float valor = ConseguirValor(ingrediente, _identificador);
            return valor > _valorMinimo;
        }
    }

    private IIdentificador _uno = new Identificador();
    private IIdentificador _dos = new Identificador();

    [Test]
    public void RequisitoSeCumpleConUnIngredienteValido()
    {
        float valorIngrediente = 5, valorNulo = 0, valorMinimo = 2;
        IIngrediente ingredienteValido = new IngredientePrueba(_uno, valorIngrediente, valorNulo);
        IRequisito requisito = new RequisitoMayor(valorMinimo, _uno);

        Assert.IsTrue(requisito.Evaluar(ingredienteValido));
    }
}
