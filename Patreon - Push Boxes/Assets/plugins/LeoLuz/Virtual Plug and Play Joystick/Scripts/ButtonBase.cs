using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LeoLuz.Extensions;

namespace LeoLuz.PlugAndPlayJoystick
{
    public class ButtonBase : MonoBehaviour
    {

        public static List<ButtonBase> ButtonsList;

        public virtual void Start()
        {
            initialize();
        }

        protected void initialize()
        {
            if (ButtonsList == null)
                ButtonsList = new List<ButtonBase>();

            ButtonsList.Add(this);
        }

        public static ButtonBase GetButtonOrKnob(string name)
        {
            for (int i = 0; i < ButtonsList.Count; i++)
            {
                if (ButtonsList[i].gameObject.name == name)
                    return ButtonsList[i];
            }
            return null;
        }

        public void Disable(float fadeOutDuration = 0f)
        {
            enabled = false;
            GetComponent<Image>().CrossFadeAlpha(0f, fadeOutDuration, true);
        }

        public void Enable(float fadeInDuration = 0f)
        {
            enabled = true;
            GetComponent<Image>().CrossFadeAlpha(1f, fadeInDuration, true);
        }

        public void Pulse(float intensity, float duration)
        {
            GetComponent<RectTransform>().Pulse(intensity, duration);
        }

        public static void DisableButton(string name, float fadeOutDuration=0f)
        {
            var obj = GetButtonOrKnob(name);
            if (obj != null)
                obj.Disable(fadeOutDuration);
        }

        public static void EnableButton(string name, float fadeOutDuration = 0f)
        {
            var obj = GetButtonOrKnob(name);
            if (obj != null)
                obj.Enable(fadeOutDuration);
        }
    }
}
