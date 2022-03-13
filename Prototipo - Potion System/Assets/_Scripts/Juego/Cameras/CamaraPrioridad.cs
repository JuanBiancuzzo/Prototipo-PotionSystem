using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    public class CamaraPrioridad : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camara;

        public void Activar()
        {
            _camara.m_Priority = 10;
        }

        public void Desactivar()
        {
            _camara.m_Priority = 1;
        }
    }
}
