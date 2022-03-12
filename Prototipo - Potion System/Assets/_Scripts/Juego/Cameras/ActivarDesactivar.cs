using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    public class ActivarDesactivar : MonoBehaviour
    {
        [SerializeField] private VoidEventoSO _eventoActivarPOV, _eventoActivaEstacion;
        [SerializeField] private CinemachineVirtualCamera _camaraPOV, _camaraEstacion;

        private void Awake()
        {
        }

        private void OnEnable()
        {
            _eventoActivarPOV.Evento += ActivarPOV;
            _eventoActivaEstacion.Evento += ActivarEstacion;
        }

        private void OnDisable()
        {
            _eventoActivarPOV.Evento -= ActivarPOV;
            _eventoActivaEstacion.Evento -= ActivarEstacion;
        }

        private void ActivarPOV()
        {
            _camaraPOV.m_Priority = 10;
            _camaraEstacion.m_Priority = 1;
        }

        private void ActivarEstacion()
        {
            _camaraEstacion.m_Priority = 10;
            _camaraPOV.m_Priority = 1;
        }
    }
}
