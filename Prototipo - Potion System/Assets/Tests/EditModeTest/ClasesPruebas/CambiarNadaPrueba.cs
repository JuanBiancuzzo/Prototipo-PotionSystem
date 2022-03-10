using System.Collections;
using System.Collections.Generic;
using ItIsNotOnlyMe;
using UnityEngine;

public class CambiarNadaPrueba : ICambiar
{
    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public Vector Modificar(Vector atributos)
    {
        return atributos;
    }
}
