using System.Collections;
using System.Collections.Generic;
using ItIsNotOnlyMe;
using UnityEngine;

public class RequisitoMayorPrueba : IRequisito
{
    private float _valorMinimo;
    private IIdentificador _identificador;

    public RequisitoMayorPrueba(float valorMinimo, IIdentificador identificador)
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
