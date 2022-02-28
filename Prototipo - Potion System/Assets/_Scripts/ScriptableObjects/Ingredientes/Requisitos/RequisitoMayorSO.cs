using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Requisito mayor", menuName = "Requisitos/Requisito mayor")]
    public class RequisitoMayorSO : RequisitoSO
    {
        [Serializable]
        private struct ParValorIdentificador
        {
            public IdentificadorSO Identificador;
            public float Valor;
        }

        [SerializeField] private List<ParValorIdentificador> _pares;

        public override float ConseguirValor(IDemandado demandado, IIdentificador identificador)
        {
            return demandado.ObtenerValor(identificador);
        }

        public override bool Evaluar(IDemandado demandado)
        {
            bool resultado = true;

            foreach (ParValorIdentificador par in _pares)
            {
                resultado &= par.Valor < ConseguirValor(demandado, par.Identificador);
            }

            return resultado;
        }
    }
}
