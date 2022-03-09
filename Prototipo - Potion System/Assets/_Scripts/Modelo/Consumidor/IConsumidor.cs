using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public interface IConsumidor
    {
        public void Consumir(IResultado resultado);
    }
}
