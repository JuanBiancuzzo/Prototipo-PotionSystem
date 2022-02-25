using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Sistema
    {        
        private Energia _energia;
        private List<IElemento> _elementos;

        public Sistema(Energia energiaInicial, List<IElemento> elementos)
        {
            _energia = energiaInicial;
            _elementos = elementos;
        }

        public void Iteracion()
        {
            _elementos = Productos(_elementos, ref _energia);
        }

        public static List<IElemento> Productos(List<IElemento> elementos, ref Energia energia)
        {
            List<IElemento> productos = new List<IElemento>();

            int cantidadElementos = 0;
            for (int i = 0; i < elementos.Count; i += 2)
            {
                IElemento elementoPrincipal = elementos[i];
                IElemento elementoSecundario = elementos[i + 1];
                cantidadElementos += 2;

                productos.AddRange(elementoPrincipal.CrearEnlace(elementoSecundario, ref energia));
            }

            if (cantidadElementos < elementos.Count)
                productos.Add(elementos[cantidadElementos + 1]);

            return productos;
        }

        /*
        public Energia EnergiaDelSistema()
        {
            return EnergiaUnSistema(_energia, _elementos);
        }

        public static Energia EnergiaUnSistema(Energia energia, List<IElemento> elementos)
        {
            Energia energiaDelSistema = Energia.Abs(energia);

            foreach (IElemento elemento in elementos)
                energiaDelSistema = Energia.Sumar(energiaDelSistema, Energia.Abs(elemento.EnergiaPotencial()));

            return energiaDelSistema;
        }*/
    }
}