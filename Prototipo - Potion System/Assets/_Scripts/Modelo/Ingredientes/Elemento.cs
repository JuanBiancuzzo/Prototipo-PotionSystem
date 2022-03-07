using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Elemento : IElemento
    {
        private List<IVinculo> _vinculos;

        private List<ICondicionDeVinculo> _condiciones;
        private List<ICambiar> _modificadores;

        private Atributos _atributosBase;

        public Elemento(Atributos atributosBase,
                           List<ICondicionDeVinculo> condiciones = null)
        {
            _vinculos = new List<IVinculo>();

            _condiciones = (condiciones == null) ? new List<ICondicionDeVinculo>() : condiciones;
            _modificadores = new List<ICambiar>();

            _atributosBase = atributosBase;
        }

        public Atributos Agregar(Atributos atributos)
        {
            Estabilidad();
            Atributos modificado = AtributoBaseModificado();
            return Atributos.Sumar(atributos, modificado);
        }

        private Atributos AtributoBaseModificado()
        {
            Atributos nuevo = _atributosBase;
            _modificadores.ForEach(modificador => nuevo = modificador.Modificar(nuevo));
            return nuevo;
        }

        public void CrearVinculo(IVinculo vinculo)
        {
            _vinculos.Add(vinculo);
        }

        public void RomperVinculo(IVinculo vinculo)
        {
            _vinculos.Remove(vinculo);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            Atributos atributos = AtributoBaseModificado();
            return atributos.GetValor(identificador);
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _modificadores.Add(modificador);
        }

        public void SacarModificador(ICambiar modificador)
        {
            _modificadores.Remove(modificador);
        }

        public bool HayVinculo(IElemento elemento)
        {
            return _vinculos.Exists(vinculo => vinculo.HayVinculo(elemento));
        }

        public ICondicionDeVinculo EncontrarCondicion(IElemento elemento)
        {
            return _condiciones.Find(condicion => condicion.Evaluar(this, elemento));
        }

        public bool PermiteVinculoCon(IVinculado vinculado)
        {
            return _condiciones.Exists(condicion => condicion.Evaluar(this, vinculado));
        }

        public void Estabilidad()
        {
            List<IVinculo> vinculosNoEstables = _vinculos.FindAll(vinculo => !vinculo.Estable());
            vinculosNoEstables.ForEach(vinculo => vinculo.RomperVinculo());
        }
    }
}