using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public class Ingrediente : IIngrediente
    {
        private List<IVinculo> _vinculos;

        private List<ICondicionDeVinculo> _condiciones;
        private List<ICambiar> _modificadores;

        private Atributos _atributosBase;

        public Ingrediente(Atributos atributosBase,
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

        public bool HayVinculo(IIngrediente ingrediente)
        {
            foreach (IVinculo vinculo in _vinculos)
                if (vinculo.HayVinculo(ingrediente))
                    return true;
            return false;
        }

        public ICondicionDeVinculo EncontrarCondicion(IIngrediente ingrediente)
        {
            foreach (ICondicionDeVinculo condicion in _condiciones)
                if (condicion.Evaluar(this, ingrediente))
                    return condicion;
            return null;
        }

        public bool PermiteVinculoCon(IVinculado vinculado)
        {
            foreach (ICondicionDeVinculo condicion in _condiciones)
                if (condicion.Evaluar(this, vinculado))
                    return true;
            return false;
        }

        public void Estabilidad()
        {
            List<IVinculo> vinculosNoEstables = new List<IVinculo>();
            foreach (IVinculo vinculo in _vinculos)
                if (!vinculo.Estable())
                    vinculosNoEstables.Add(vinculo);
            vinculosNoEstables.ForEach(vinculo => vinculo.RomperVinculo());
        }
    }
}