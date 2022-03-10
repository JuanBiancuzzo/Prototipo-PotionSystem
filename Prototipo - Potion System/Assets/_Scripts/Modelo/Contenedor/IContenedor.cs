﻿namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public bool AgregarElemento(IElemento elemento);

        public void Mezclar(IElemento elemento1, IElemento elemento2);

        public Vector CalcularEstado();

        public bool Lleno();

        public void Transferir(IContenedor contenedor);

        public IResultado ConseguirResultado();
    }
}
