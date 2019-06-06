using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using LeoLuz.Utilities;
#endif


namespace LeoLuz.PropertyAttributes
{
    public class InputAxesListDropdownAttribute : PropertyAttribute
    {
        public bool hideLabel;
        public InputAxesListDropdownAttribute(bool hideLabel = false)
        {
            this.hideLabel = hideLabel;
        }
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(InputAxesListDropdownAttribute))]
    public class InputAxisListDropdownDrawer : PropertyDrawer
    {
        InputAxesListDropdownAttribute inputAxisDropdownAttribute { get { return ((InputAxesListDropdownAttribute)attribute); } }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            object[] axesPackage = InputUtility.GetAxes();
            List<string> AxisLabelList = (List<string>)axesPackage[0];


            //find choice Index
            var choiceIndex = AxisLabelList.IndexOf(property.stringValue);

            if (inputAxisDropdownAttribute.hideLabel)
                choiceIndex = EditorGUI.Popup(position, choiceIndex, AxisLabelList.ToArray());
            else
                choiceIndex = EditorGUI.Popup(position, label.text, choiceIndex, AxisLabelList.ToArray());
            if (choiceIndex == -1)
                choiceIndex = 0;
            property.stringValue = AxisLabelList[choiceIndex];
        }
    }
#endif
}
