using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeoLuz.Extensions;
#if UNITY_EDITOR
using UnityEditor;
using System.Reflection;
#endif

namespace LeoLuz.PropertyAttributes
{
    public class hideIf : PropertyAttribute
    {

        public string varName;
        public object value;
        public bool skipLine;
        public bool readOnly;
        public float labelWidth;
        public float valueWidth;
        public bool withMold;
        /// <summary>
        /// (string varToCheck, object ValueToCheck,drawNextInThisLine?, readOnly?)
        /// If skipline is true, inspector will discart the line and draw next field in same line
        /// </summary>
        public hideIf(string varToCheck, object ValueToCheck, bool drawNextInThisLine = true, bool readOnly = false, float labelWidth = 0, float valueWidth = 0)
        {
            this.varName = varToCheck;
            this.value = ValueToCheck;
            this.skipLine = drawNextInThisLine;
            this.readOnly = readOnly;
            this.labelWidth = labelWidth;
            this.valueWidth = valueWidth;
        }
        public hideIf(string varToCheck, object ValueToCheck, bool withMold)
        {
            this.varName = varToCheck;
            this.value = ValueToCheck;
            this.withMold = withMold;

        }
        public hideIf(string value, float labelWidth = 0, float valueWidth = 0)
        {
            this.value = value;
            this.labelWidth = labelWidth;
            this.valueWidth = valueWidth;
        }
        public hideIf(string varToCheck, object ValueToCheck, float labelWidth, float valueWidth, bool drawNextInThisLine = true, bool readOnly = false)
        {
            this.varName = varToCheck;
            this.value = ValueToCheck;
            this.skipLine = drawNextInThisLine;
            this.readOnly = readOnly;
            this.labelWidth = labelWidth;
            this.valueWidth = valueWidth;
        }

        public IDictionary<object, bool> hideList;

        public bool CheckHided(object parent)
        {
            if (parent == null)
                return false;

            if (hideList == null || !hideList.ContainsKey(parent))
            {
                return false;
            }
            return hideList[parent];
        }

        public void hide(object prop, bool hided)
        {
            if (hideList == null)
                hideList = new Dictionary<object, bool>();

            if (hideList.ContainsKey(prop))
            {
                hideList[prop] = hided;
            }
            else
            {
                hideList.Add(prop, hided);
            }
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(hideIf))]
    public class HideIfDrawer : PropertyDrawer
    {

        hideIf target { get { return ((hideIf)attribute); } }

        public static float LastUpdate;
        public static float LastPosition;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (LastUpdate == Time.time && LastPosition == position.y)
                position.y += position.height;

            object parent = property.GetParent();
            if (parent == null)
                return;

            if (target.varName == null)
            {


                if (property.floatValue.ToString() != target.value.ToString())
                {

                    EditorGUI.PropertyField(position, property, label, true);

                    target.skipLine = false;
                    target.hide(parent, false);
                }
                else
                {
                    target.skipLine = true;
                    target.hide(parent, true);
                }
                return;
            }

            FieldInfo fieldToCheck = parent.GetType().GetField(target.varName);
            object obj = fieldToCheck.GetValue(parent);

            if (obj.ToString() == target.value.ToString())
            {
                if (target.skipLine)
                    target.hide(parent, true);
            }
            else
            {
                target.hide(parent, false);

                if (target.readOnly)
                    GUI.enabled = false;

                EditorGUI.PropertyField(position, property, label, true);

            }
            //   Debug.Log(property.name+" - "+Time.time);  
            LastUpdate = Time.time;
            LastPosition = position.y;
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (target.skipLine && target.CheckHided(property.GetParent()))
                return -EditorGUIUtility.standardVerticalSpacing;
            else
                return EditorGUI.GetPropertyHeight(property, label) + 3f;

        }
    }
#endif
}