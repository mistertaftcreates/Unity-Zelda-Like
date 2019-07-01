#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;

namespace LeoLuz.Utilities
{
    public class InputUtility
    {
        /// <summary>
        /// Get Axis list from unity configuration
        /// </summary>
        private static void ReadAxes()
        {
            var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

            SerializedObject obj = new SerializedObject(inputManager);

            SerializedProperty axisArray = obj.FindProperty("m_Axes");

            if (axisArray.arraySize == 0)
                Debug.Log("No Axes");

            for (int i = 0; i < axisArray.arraySize; ++i)
            {
                var axis = axisArray.GetArrayElementAtIndex(i);

                var name = axis.FindPropertyRelative("m_Name").stringValue;
                var axisVal = axis.FindPropertyRelative("axis").intValue;
                var negativeButton = axis.FindPropertyRelative("negativeButton").stringValue;
                var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

                Debug.Log(name);
                Debug.Log("negativeButton" + negativeButton);
                Debug.Log(axisVal);
                Debug.Log(inputType);

            }
            Debug.Log("inputType");
        }

        public static object[] GetAxes()
        {
            var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

            if (inputManager == null)
                return null;

            SerializedObject obj = new SerializedObject(inputManager);

            SerializedProperty axisArray = obj.FindProperty("m_Axes");

            if (axisArray.arraySize == 0)
                Debug.Log("No Axes");

            List<string> AxesLabelList = new List<string>();
            List<Axis> AxesList = new List<Axis>();

            //AxesList.Add(new Axis("", true));
            //AxesLabelList.Add(" ");

            for (int i = 0; i < axisArray.arraySize; ++i)
            {
                var axis = axisArray.GetArrayElementAtIndex(i);
                //axis.PrintChildList();
                var name = axis.FindPropertyRelative("m_Name").stringValue;

                var negativeButton = axis.FindPropertyRelative("negativeButton").stringValue;
                var type = axis.FindPropertyRelative("type").enumValueIndex;


                if (!AxesLabelList.Contains(name))
                {
                    AxesList.Add(new Axis(name, negativeButton != "" || type != 0 ? true : false));
                    AxesLabelList.Add(name);

                }
                else
                {
                    Axis AxisElement = AxesList[AxesLabelList.IndexOf(name)];
                    if (!AxisElement.isAxis)
                        AxisElement.isAxis = negativeButton != "" ? true : false;

                }
                //			if( negativeButton!="")
                //				Debug.Log("NEGA "+name);

            }
            object[] AxesPackage = new object[] { AxesLabelList, AxesList };
            return AxesPackage;
        }

        public static object[] GetBipolarAxes()
        {
            object[] AxesListPackage = GetAxes();
            //Remove non bipolar axes
            List<InputUtility.Axis> AxesList = (List<InputUtility.Axis>)AxesListPackage[1];
            List<string> AxesStringList = (List<string>)AxesListPackage[0];
            for (int i = 0; i < AxesList.Count; i++)
            {
                if (!AxesList[i].isAxis)
                {
                    AxesList.Remove(AxesList[i]);
                    AxesStringList.Remove(AxesStringList[i]);
                    i--;
                }
            }
            AxesListPackage[0] = AxesStringList;
            AxesListPackage[1] = AxesList;
            return AxesListPackage;
        }

        public enum InputType
        {
            KeyOrMouseButton,
            MouseMovement,
            JoystickAxis,
        };

        //[MenuItem("Assets/ReadInputManager")]
        //public static void DoRead()
        //{
        //    ReadAxes();
        //}

        public class Axis
        {
            public string name;
            public bool isAxis;
            public int JoystickNumber;
            public Axis(string name, bool HasNegative, int JoystickNumber = 0)
            {
                this.name = name;
                this.isAxis = HasNegative;
                this.JoystickNumber = JoystickNumber;
            }
        }
    }

    //public class InputUtility2
    //{

    //    public static string[] Keys = new string[238]
    //    {
    //        //"joystick button 0",
    //        //"joystick button 1",
    //        //"joystick button 2",
    //        //"joystick button 3",
    //        //"joystick button 4",
    //        //"joystick button 5",
    //        //"joystick button 6",
    //        //"joystick button 7",
    //        //"joystick button 8",
    //        //"joystick button 9",
    //        //"joystick button 10",
    //        //"joystick button 11",
    //        //"joystick button 12",
    //        //"joystick button 13",
    //        //"joystick button 14",
    //        //"joystick button 15",
    //        //"joystick button 16",
    //        //"joystick button 17",
    //        //"joystick button 18",
    //        //"joystick button 19",
    //        "joystick 1 button 0",
    //        "joystick 1 button 1",
    //        "joystick 1 button 2",
    //        "joystick 1 button 3",
    //        "joystick 1 button 4",
    //        "joystick 1 button 5",
    //        "joystick 1 button 6",
    //        "joystick 1 button 7",
    //        "joystick 1 button 8",
    //        "joystick 1 button 9",
    //        "joystick 1 button 10",
    //        "joystick 1 button 11",
    //        "joystick 1 button 12",
    //        "joystick 1 button 13",
    //        "joystick 1 button 14",
    //        "joystick 1 button 15",
    //        "joystick 1 button 16",
    //        "joystick 1 button 17",
    //        "joystick 1 button 18",
    //        "joystick 1 button 19",
    //        "joystick 2 button 0",
    //        "joystick 2 button 1",
    //        "joystick 2 button 2",
    //        "joystick 2 button 3",
    //        "joystick 2 button 4",
    //        "joystick 2 button 5",
    //        "joystick 2 button 6",
    //        "joystick 2 button 7",
    //        "joystick 2 button 8",
    //        "joystick 2 button 9",
    //        "joystick 2 button 10",
    //        "joystick 2 button 11",
    //        "joystick 2 button 12",
    //        "joystick 2 button 13",
    //        "joystick 2 button 14",
    //        "joystick 2 button 15",
    //        "joystick 2 button 16",
    //        "joystick 2 button 17",
    //        "joystick 2 button 18",
    //        "joystick 2 button 19",
    //        "joystick 3 button 0",
    //        "joystick 3 button 1",
    //        "joystick 3 button 2",
    //        "joystick 3 button 3",
    //        "joystick 3 button 4",
    //        "joystick 3 button 5",
    //        "joystick 3 button 6",
    //        "joystick 3 button 7",
    //        "joystick 3 button 8",
    //        "joystick 3 button 9",
    //        "joystick 3 button 10",
    //        "joystick 3 button 11",
    //        "joystick 3 button 12",
    //        "joystick 3 button 13",
    //        "joystick 3 button 14",
    //        "joystick 3 button 15",
    //        "joystick 3 button 16",
    //        "joystick 3 button 17",
    //        "joystick 3 button 18",
    //        "joystick 3 button 19",
    //        "joystick 4 button 0",
    //        "joystick 4 button 1",
    //        "joystick 4 button 2",
    //        "joystick 4 button 3",
    //        "joystick 4 button 4",
    //        "joystick 4 button 5",
    //        "joystick 4 button 6",
    //        "joystick 4 button 7",
    //        "joystick 4 button 8",
    //        "joystick 4 button 9",
    //        "joystick 4 button 10",
    //        "joystick 4 button 11",
    //        "joystick 4 button 12",
    //        "joystick 4 button 13",
    //        "joystick 4 button 14",
    //        "joystick 4 button 15",
    //        "joystick 4 button 16",
    //        "joystick 4 button 17",
    //        "joystick 4 button 18",
    //        "joystick 4 button 19",
    //        "joystick 5 button 0",
    //        "joystick 5 button 1",
    //        "joystick 5 button 2",
    //        "joystick 5 button 3",
    //        "joystick 5 button 4",
    //        "joystick 5 button 5",
    //        "joystick 5 button 6",
    //        "joystick 5 button 7",
    //        "joystick 5 button 8",
    //        "joystick 5 button 9",
    //        "joystick 5 button 10",
    //        "joystick 5 button 11",
    //        "joystick 5 button 12",
    //        "joystick 5 button 13",
    //        "joystick 5 button 14",
    //        "joystick 5 button 15",
    //        "joystick 5 button 16",
    //        "joystick 5 button 17",
    //        "joystick 5 button 18",
    //        "joystick 5 button 19",
    //        "joystick 6 button 0",
    //        "joystick 6 button 1",
    //        "joystick 6 button 2",
    //        "joystick 6 button 3",
    //        "joystick 6 button 4",
    //        "joystick 6 button 5",
    //        "joystick 6 button 6",
    //        "joystick 6 button 7",
    //        "joystick 6 button 8",
    //        "joystick 6 button 9",
    //        "joystick 6 button 10",
    //        "joystick 6 button 11",
    //        "joystick 6 button 12",
    //        "joystick 6 button 13",
    //        "joystick 6 button 14",
    //        "joystick 6 button 15",
    //        "joystick 6 button 16",
    //        "joystick 6 button 17",
    //        "joystick 6 button 18",
    //        "joystick 6 button 19",
    //        "joystick 7 button 0",
    //        "joystick 7 button 1",
    //        "joystick 7 button 2",
    //        "joystick 7 button 3",
    //        "joystick 7 button 4",
    //        "joystick 7 button 5",
    //        "joystick 7 button 6",
    //        "joystick 7 button 7",
    //        "joystick 7 button 8",
    //        "joystick 7 button 9",
    //        "joystick 7 button 10",
    //        "joystick 7 button 11",
    //        "joystick 7 button 12",
    //        "joystick 7 button 13",
    //        "joystick 7 button 14",
    //        "joystick 7 button 15",
    //        "joystick 7 button 16",
    //        "joystick 7 button 17",
    //        "joystick 7 button 18",
    //        "joystick 7 button 19",
    //        "joystick 8 button 0",
    //        "joystick 8 button 1",
    //        "joystick 8 button 2",
    //        "joystick 8 button 3",
    //        "joystick 8 button 4",
    //        "joystick 8 button 5",
    //        "joystick 8 button 6",
    //        "joystick 8 button 7",
    //        "joystick 8 button 8",
    //        "joystick 8 button 9",
    //        "joystick 8 button 10",
    //        "joystick 8 button 11",
    //        "joystick 8 button 12",
    //        "joystick 8 button 13",
    //        "joystick 8 button 14",
    //        "joystick 8 button 15",
    //        "joystick 8 button 16",
    //        "joystick 8 button 17",
    //        "joystick 8 button 18",
    //        "joystick 8 button 19",
    //        "up",
    //        "down",
    //        "right",
    //        "left",
    //        "backspace",
    //        "tab",
    //        "return",
    //        "escape",
    //        "space",
    //        "a",
    //        "b",
    //        "c",
    //        "d",
    //        "e",
    //        "f",
    //        "g",
    //        "h",
    //        "i",
    //        "j",
    //        "k",
    //        "l",
    //        "m",
    //        "n",
    //        "o",
    //        "p",
    //        "q",
    //        "r",
    //        "s",
    //        "t",
    //        "u",
    //        "v",
    //        "w",
    //        "x",
    //        "y",
    //        "z",
    //        "right shift",
    //        "left shift",
    //        "right ctrl",
    //        "left ctrl",
    //        "right alt",
    //        "left alt",
    //        "[0]",
    //        "[1]",
    //        "[2]",
    //        "[3]",
    //        "[4]",
    //        "[5]",
    //        "[6]",
    //        "[7]",
    //        "[8]",
    //        "[9]",
    //        "mouse 0",
    //        "mouse 1",
    //        "mouse 2",
    //        "mouse 3",
    //        "mouse 4",
    //        "mouse 5",
    //        "mouse 6",
    //        "delete",
    //        "insert",
    //        "home",
    //        "end",
    //        "page up",
    //        "page down",
    //        "f1",
    //        "f2",
    //        "f3",
    //        "f4",
    //        "f5",
    //        "f6",
    //        "f7",
    //        "f8",
    //        "f9",
    //        "f10",
    //        "f11",
    //        "f12",
    //        "right cmd",
    //        "left cmd"
    //    };


    //}


}
#endif