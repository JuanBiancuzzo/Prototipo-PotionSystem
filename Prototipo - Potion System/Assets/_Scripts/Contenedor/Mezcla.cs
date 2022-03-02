using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Mezcla
    {
        private Atributos _estado;

        private List<IIngrediente> _ingredientes;

        public Mezcla(Atributos estado)
        {
            _estado = estado;
            _ingredientes = new List<IIngrediente>();
        }

        public void Agregar(IIngrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
        }

        public void Mezclar()
        {
            IIngrediente principal = null, secundario = null;
            bool encontradoEnlace = false;

            for (int i = 0; i < _ingredientes.Count && !encontradoEnlace; i++)
            {
                principal = _ingredientes[i];
                if (!principal.PermiteUnirse())
                    continue;

                for (int j = i + 1; j < _ingredientes.Count && !encontradoEnlace; j++)
                {
                    secundario = _ingredientes[j];
                    if (!secundario.PermiteUnirse())
                        continue;

                    if (principal.PermiteUnirseCon(secundario) && secundario.PermiteUnirseCon(principal))
                        encontradoEnlace = true;
                }
            }

            if (!encontradoEnlace)
                return;

            IIngrediente compuesto = principal.Unirse(secundario);
            if (compuesto == null)
            {
                Debug.LogError("De alguna forma en la mezcla se unieron dos ingredientes que no se podrian unir");
                return;
            }

            _ingredientes.Remove(principal);
            _ingredientes.Remove(secundario);
            _ingredientes.Add(compuesto);
        }

        public Atributos CalcularEstado()
        {
            Atributos atributos = _estado;
            _ingredientes.ForEach(ingredientes => atributos = ingredientes.Agregar(atributos));
            return atributos;
        }

        public void Finalizar()
        {
            _ingredientes.Clear();
        }
    }
}
