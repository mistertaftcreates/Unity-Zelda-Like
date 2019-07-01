using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LeoLuz.Extensions
{
    public static class CanvasExtension
    {
        public static Vector3 CanvasPositionToWorldPosition(this Canvas canvas, Vector3 position)
        {
            RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
            return (position * CanvasRect.localScale.x) + canvas.transform.position;
        }

        public static Vector3 WorldPositionToCanvasPosition(this Canvas canvas, Vector3 position)
        {
            RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
            var relativePos = position - canvas.transform.position;
            return (relativePos / CanvasRect.localScale.x);
        }
    }
}