using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Cambiar mayor", menuName = "Cambios/Cambiar mayor")]
    public class CambiarSumaSO : CambiarSO
    {
        [Serializable]
        private struct ParValorIdentificador
        {
            public IdentificadorSO Identificador;
            public float Valor;
        }

        [SerializeField] private List<ParValorIdentificador> _pares;

        public override void Cambiar(ICambiante cambiante)
        {
            cambiante.AgregarModificador(this);
        }

        public override float Modificar(IIdentificador identificador, float valor)
        {
            float valorFinal = valor;

            _pares.ForEach(par =>
            {
                if (par.Identificador.EsIgual(identificador))
                    valorFinal += par.Valor;
            });

            return valorFinal;
        }
    }
}
