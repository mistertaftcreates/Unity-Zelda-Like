using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using LeoLuz;
using System;
using LeoLuz.PropertyAttributes;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LeoLuz.PlugAndPlayJoystick
{
    [RequireComponent(typeof(Rect))]
    public class UIButtonToAxis : ButtonBase, IPointerDownHandler, IPointerUpHandler,  IPointerEnterHandler, IPointerExitHandler
    {
        [InputAxesListDropdown]
        public string AxisName="Horizontal";
        [Range(-1f, 1f)]
        public float Value;
        private float CurrentValue;
        private bool pressed;
#if UNITY_EDITOR
        private bool OrderOfScriptChanged;

        public void OnDrawGizmosSelected()
        {
            if (!OrderOfScriptChanged)
            {
                // Get the name of the script we want to change it's execution order
                string scriptName = typeof(UIButtonToAxis).Name;

                // Iterate through all scripts (Might be a better way to do this?)
                foreach (MonoScript monoScript in MonoImporter.GetAllRuntimeMonoScripts())
                {
                    // If found our script
                    if (monoScript.name == scriptName && MonoImporter.GetExecutionOrder(monoScript) != -2000)
                    {
                        MonoImporter.SetExecutionOrder(monoScript, -2000);
                    }
                }
                OrderOfScriptChanged = true;
            } 

        }
#endif
        public override void Start()
        {
            base.Start();
            Input.RegisterAxisMobile(AxisName);
        }

        public void FixedUpdate()
        {
            if (pressed)
            {
                Input.PressButtonMobile(AxisName);
                CurrentValue = Value;
                Input.SetAxisMobile(AxisName, CurrentValue);
            }
        }

        public virtual void OnPointerDown(PointerEventData data)
        {
            Input.PressButtonDownMobile(AxisName);
            CurrentValue = Value;
            Input.SetAxisMobile(AxisName, CurrentValue);
            pressed = true;
        }

        public virtual void OnPointerUp(PointerEventData data)
        {
            pressed = false;
            Input.PressButtonUpMobile(AxisName);
            CurrentValue = 0f;
            Input.SetAxisMobile(AxisName, CurrentValue);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
#if UNITY_EDITOR
            if (!Input.GetMouseButton(0))
                return;
#endif
            Input.PressButtonDownMobile(AxisName);
            CurrentValue = Value;
            Input.SetAxisMobile(AxisName, CurrentValue);
            pressed = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
#if UNITY_EDITOR
            if (!Input.GetMouseButton(0))
                return;
#endif
            pressed = false;
            Input.PressButtonUpMobile(AxisName);
            CurrentValue = 0f;
            Input.SetAxisMobile(AxisName, CurrentValue);
        }
    }

}