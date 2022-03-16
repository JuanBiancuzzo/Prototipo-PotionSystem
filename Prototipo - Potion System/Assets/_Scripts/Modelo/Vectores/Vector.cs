using System;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.VectorDinamico
{

    public class Vector
    {
        private IComponente _cadena;

        public Vector(IComponente componente)
        {
            _cadena = componente;
        }

        public Vector(List<IComponente> componentes)
        {
            _cadena = componentes[0];
            for (int i = 1; i < componentes.Count; i++)
                _cadena.Sumar(componentes[i]);
        }

        public bool EsIgual(Vector vector)
        {
            Vector diferencia = Restar(vector);
            return (float)Math.Round(diferencia.ProductoInterno(diferencia), 4) == 0f;
        }

        public Vector Sumar(Vector vector)
        {
            IComponente nuevaCadena = NuevaCadna();
            nuevaCadena.Sumar(vector.NuevaCadna());
            return new Vector(nuevaCadena);
        }

        public Vector Restar(Vector vector)
        {
            IComponente nuevaCadena = NuevaCadna();
            nuevaCadena.Restar(vector.NuevaCadna());
            return new Vector(nuevaCadena);
        }

        public Vector Multiplicar(float escalar)
        {
            IComponente nuevaCadena = NuevaCadna();
            nuevaCadena.Multiplicar(escalar);
            return new Vector(nuevaCadena);
        }

        public Vector Multiplicar(float escalar, IIdentificador identificador)
        {
            IComponente nuevaCadena = NuevaCadna();
            nuevaCadena.Multiplicar(escalar, identificador);
            return new Vector(nuevaCadena);
        }

        public Vector Dividir(float escalar)
        {
            IComponente nuevaCadena = NuevaCadna();
            nuevaCadena.Dividir(escalar);
            return new Vector(nuevaCadena);
        }

        public float ProductoInterno(Vector vector)
        {
            return _cadena.ProductoInterno(vector._cadena);
        }

        private IComponente NuevaCadna()
        {
            return _cadena.Copia();
        }

        public static Vector VectorNulo()
        {
            return new Vector(new ComponenteNulo());
        }
    }
}
