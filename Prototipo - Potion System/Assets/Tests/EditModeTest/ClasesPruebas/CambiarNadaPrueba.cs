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

    public Atributos Modificar(Atributos atributos)
    {
        return atributos;
    }
}
