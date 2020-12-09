using Mechatronics.SystemGraph;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GUIDCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CleanGUID()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {            
            GameObjectGUID[] guids = go.GetComponents<GameObjectGUID>();
            foreach (var guid in guids)
            {
                Debug.Log("Removing GameObjectGUID from " + go.name);
                GameObject.DestroyImmediate(guid);
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GUIDCleaner))]
public class GUIDCleanerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Clean"))
        {
            GUIDCleaner cleaner = (GUIDCleaner)target;
            cleaner.CleanGUID();
        }
    }
}
#endif

