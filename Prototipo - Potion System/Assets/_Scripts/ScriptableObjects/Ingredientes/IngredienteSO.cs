using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Ingrediente simple", menuName = "Ingredientes/Ingrediente")]
    public class IngredienteSO : ScriptableObject, IIngrediente
    {
        [Serializable]
        private struct ParIdValor
        {
            [SerializeField] public IdentificadorSO Identificador;
            [SerializeField] [Range(-20, 20)] public float Valor;
        }

        [SerializeField] List<ParIdValor> _parIdValores;

        [SerializeField]
        private List<RequisitoSO> _requisitos;
        [SerializeField]
        private List<CambiarSO> _cambios;


        private IIngrediente _ingredienteBase;
        public IIngrediente Ingrediente
        {
            get
            {
                if (_ingredienteBase == null)
                {
                    List<ICambiar> cambios = new List<ICambiar>();
                    cambios.AddRange(_cambios);

                    List<IRequisito> requisitos = new List<IRequisito>();
                    requisitos.AddRange(_requisitos);

                    List<Par> pares = new List<Par>();
                    foreach (ParIdValor par in _parIdValores)
                        pares.Add(new Par(par.Identificador, par.Valor));

                    _ingredienteBase = new Ingrediente(new Atributos(pares), cambios, requisitos);
                }
                return _ingredienteBase;
            }
        }
        
        public Atributos Agregar(Atributos atributos)
        {
            return Ingrediente.Agregar(atributos);
        }

        public void AgregarModificador(ICambiar modificador)
        {
            Ingrediente.AgregarModificador(modificador);
        }

        public void ModificarOtro(IIngrediente ingrediente)
        {
            Ingrediente.ModificarOtro(ingrediente);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            return Ingrediente.ObtenerValor(identificador);
        }

        public bool PermiteUnirse()
        {
            return Ingrediente.PermiteUnirse();
        }

        public IIngrediente Unirse(IIngrediente ingrediente)
        {
            return Ingrediente.Unirse(ingrediente);
        }
    }
}
