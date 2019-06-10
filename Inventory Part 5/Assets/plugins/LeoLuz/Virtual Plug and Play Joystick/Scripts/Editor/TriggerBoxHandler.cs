using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TriggerHandler  {

    public static void Box(ref Bounds bounds, Vector3 RelativeToPosition, string content = "", bool flipX=false, bool flipY=false)
    {
        if (Application.isPlaying)
            return;

        float size = HandleUtility.GetHandleSize(RelativeToPosition) * 0.05f;
        Vector3 snap = Vector3.one * 0.5f;        

        GUIStyle label = new GUIStyle();
        label.normal.textColor = new Color(Handles.color.r+0.5f, Handles.color.g+0.5f, Handles.color.b+0.5f,1f);
        label.alignment = TextAnchor.MiddleCenter;
        label.fontSize = 12;

        var originalMax = bounds.max;
        var originalMin = bounds.min;
        var originalCenter = bounds.center;

        EditorGUI.BeginChangeCheck();

        if (flipX)
        {
            originalMax.x = -originalMax.x;
            originalMin.x = -originalMin.x;
            originalCenter.x = -originalCenter.x;
        }
        if (flipY)
        {
            originalMax.y = -originalMax.y;
            originalMin.y = -originalMin.y;
            originalCenter.y = -originalCenter.y;
        }
        //Drawing the handles
        var Max = new Vector3();
        var Min = new Vector3();
        if (!Application.isPlaying)
        {
            Max = Handles.FreeMoveHandle(RelativeToPosition + originalMax, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
            Min = Handles.FreeMoveHandle(RelativeToPosition + originalMin, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
        }
        else
        {
            Max = RelativeToPosition + originalMax;
            Min = RelativeToPosition + originalMin;
        }

        Vector3 MaxMin = new Vector3(Max.x, Min.y, Max.z);

        if (!Application.isPlaying)
            MaxMin = Handles.FreeMoveHandle(MaxMin, Quaternion.identity, size, snap, Handles.RectangleHandleCap);

        Max.x = MaxMin.x;
        Min.y = MaxMin.y;
        Vector3 MinMax = new Vector3(Min.x, Max.y, Max.z); if (!Application.isPlaying)
            if (!Application.isPlaying)
                MinMax = Handles.FreeMoveHandle(MinMax, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
        Min.x = MinMax.x;
        Max.y = MinMax.y;

        //Drawing the lines
        Handles.DrawLine(Min, MinMax);
        Handles.DrawLine(MinMax, Max);
        Handles.DrawLine(Max, MaxMin);
        Handles.DrawLine(MaxMin, Min);


        //Inverting the values

        var newMax = Max - RelativeToPosition;
        var newMin = Min - RelativeToPosition;
        if (flipX)
        {
            newMax.x = -newMax.x;
            newMin.x = -newMin.x;
        }
        if (flipY)
        {
            newMax.y = -newMax.y;
            newMin.y = -newMin.y;
        }
        if (newMax.x < newMin.x)
            newMin.x = newMax.x;
        if (newMax.y < newMin.y)
            newMin.y = newMax.y;

        if (EditorGUI.EndChangeCheck())
        {
            bounds.max = newMax;
            bounds.min = newMin;
        }


        EditorGUI.BeginChangeCheck();
        bounds.center = Handles.FreeMoveHandle(RelativeToPosition + bounds.center, Quaternion.identity, size, snap, Handles.CircleHandleCap) - RelativeToPosition;
        Handles.Label(RelativeToPosition + (new Vector3((newMax.x + newMin.x) * 0.5f * (flipX ? -1f : 1f), newMax.y)), content, label);



    }

    public static void Circle(ref Vector3 point, ref float radius,  Vector3 RelativeToPosition, string content = "")
    {
        float size = HandleUtility.GetHandleSize(RelativeToPosition) * 0.05f;
        Vector3 snap = Vector3.one * 0.5f;

        var newPoint = Handles.FreeMoveHandle(RelativeToPosition + point, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
        point = newPoint-RelativeToPosition;

      //  var newRadius = Handles.FreeMoveHandle(RelativeToPosition + point+(Vector3.down*radius), Quaternion.identity, size, snap, Handles.RectangleHandleCap);

     //   radius = Vector3.Distance(newPoint, newRadius);
        radius = Handles.RadiusHandle(Quaternion.identity, RelativeToPosition + point, radius,true);

        Handles.DrawWireDisc(newPoint, Vector3.forward, radius);

        GUIStyle label = new GUIStyle();
        label.normal.textColor = new Color(Handles.color.r + 0.5f, Handles.color.g + 0.5f, Handles.color.b + 0.5f, 1f);
        label.alignment = TextAnchor.MiddleCenter;
        label.fontSize = 12;
        Handles.Label(RelativeToPosition + point, content, label);
    }

}
