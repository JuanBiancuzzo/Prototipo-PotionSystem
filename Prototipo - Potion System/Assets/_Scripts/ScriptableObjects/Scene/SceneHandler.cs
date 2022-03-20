using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Scene handler", menuName = "Scene handler")]
public class SceneHandler : ScriptableObject
{
    [SerializeField] private Scene _escena;
    [SerializeField] private List<SceneTransition> _transiciones = new List<SceneTransition>();


    #if UNITY_EDITOR
    [ContextMenu("Crear transicion")]
    private void CrearTransicion()
    {
        SceneTransition sceneTransition = CreateInstance<SceneTransition>();
        sceneTransition.name = "Nueva transicion " + _transiciones.Count.ToString();
        _transiciones.Add(sceneTransition);

        AssetDatabase.AddObjectToAsset(sceneTransition, this);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(sceneTransition);
    }
    #endif
}
