using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using LeoLuz.PropertyAttributes;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LeoLuz.PlugAndPlayJoystick
{
    [RequireComponent(typeof(Rect))]
    public class UIButtonToButton : ButtonBase, IPointerDownHandler, IPointerUpHandler
    {
        [InputAxesListDropdown]
        public string ButtonName;
        [ReadOnlyInPlayMode]
        public bool pressed;

        #if UNITY_EDITOR
        private bool OrderOfScriptChanged;

        public void OnDrawGizmosSelected()
        {
            if (!OrderOfScriptChanged)
            {
                // Get the name of the script we want to change it's execution order
                string scriptName = typeof(UIButtonToButton).Name;

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
        }
        public void Update()
        {
            if (pressed)
                Input.PressButtonMobile(ButtonName);

            //print("Update>" + Time.frameCount);
        }

        public void FixedUpdate()
        {
            if (pressed)
                Input.PressButtonMobile(ButtonName);

            //print("FixedUpdate>" + Time.frameCount);
        }

        void LateUpdate()
        {
            //print("LateUpdate>" + Time.frameCount);
        }

        public virtual void OnPointerDown(PointerEventData data)
        {
            Input.PressButtonDownMobile(ButtonName);
        }

        public virtual void OnPointerUp(PointerEventData data)
        {
            pressed = false;
            Input.PressButtonUpMobile(ButtonName);
        }

    }

}