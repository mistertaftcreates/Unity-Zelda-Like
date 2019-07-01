using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(TriggerBoxHandlerSample))]
public class TriggerBoxHandlerSampleEditor : Editor
{     
    protected virtual void OnSceneGUI()
    {
        TriggerBoxHandlerSample _inspected = (TriggerBoxHandlerSample)target;
        Handles.color = Color.cyan;
        TriggerHandler.Box(ref _inspected.boundTest, _inspected.transform.position, "blablabla");
        TriggerHandler.Circle(ref _inspected.overlapPoint, ref _inspected.Radius, _inspected.transform.position);
    }  
}