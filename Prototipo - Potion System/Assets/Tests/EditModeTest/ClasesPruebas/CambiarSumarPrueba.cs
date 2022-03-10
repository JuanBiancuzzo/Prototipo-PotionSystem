using ItIsNotOnlyMe;
using System.Collections.Generic;

public class CambiarSumarPrueba : ICambiar
{
    private Vector _vector;

    public CambiarSumarPrueba(float valorSumar, IIdentificador identificador)
    {
        _vector = new Vector(new Componente(identificador, valorSumar));
    }

    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public Vector Modificar(Vector atributos)
    {
        return atributos.Sumar(_vector);
    }
}
