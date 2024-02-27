using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UniversialTester : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent TriggerEvent;

    public void Trigger()
    {
        TriggerEvent.Invoke();
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(UniversialTester))]
class UniversialTesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UniversialTester debugger = (UniversialTester)target;
        if (GUILayout.Button("Trigger"))
            debugger.Trigger();
    }
}

#endif
