using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : ScriptableObject
{
    [SerializeField] string _nombre;
    [SerializeField] SceneHandler _targetSence;
}
