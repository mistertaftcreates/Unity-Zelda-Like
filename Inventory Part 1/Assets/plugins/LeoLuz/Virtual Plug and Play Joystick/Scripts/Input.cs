using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*this is a usurpator script of the Input, it intercepts the calls of the same, and merges them with the inputs made by the virtual joystick, in this way any game that uses standard axes will be intercepted.
 */
public class Input : MonoBehaviour
{
    #region INPUT API OVERRIDINGS
    public static bool simulateMouseWithTouches { get { return UnityEngine.Input.simulateMouseWithTouches; } set { UnityEngine.Input.simulateMouseWithTouches = value; } }
    public static bool anyKey { get { return UnityEngine.Input.anyKey; } }
    public static bool anyKeyDown { get { return UnityEngine.Input.anyKeyDown; } }
    public static string inputString { get { return UnityEngine.Input.inputString; } }
    public static Vector3 acceleration { get { return UnityEngine.Input.acceleration; } }
    public static AccelerationEvent[] accelerationEvents { get { return UnityEngine.Input.accelerationEvents; } }
    public static int accelerationEventCount { get { return UnityEngine.Input.accelerationEventCount; } }
    public static Touch[] touches { get { return UnityEngine.Input.touches; } }
    public static int touchCount { get { return UnityEngine.Input.touchCount; } }
    public static bool mousePresent { get { return UnityEngine.Input.mousePresent; } }
    [System.Obsolete("eatKeyPressOnTextFieldFocus property is deprecated, and only provided to support legacy behavior.")]
    public static bool eatKeyPressOnTextFieldFocus { get { return UnityEngine.Input.eatKeyPressOnTextFieldFocus; } set { UnityEngine.Input.eatKeyPressOnTextFieldFocus = value; } }
    public static bool stylusTouchSupported { get { return UnityEngine.Input.stylusTouchSupported; } }
    public static bool touchSupported { get { return UnityEngine.Input.touchSupported; } }
    public static bool multiTouchEnabled { get { return UnityEngine.Input.multiTouchEnabled; } set { UnityEngine.Input.multiTouchEnabled = value; } }
    public static LocationService location { get { return UnityEngine.Input.location; } }
    public static Compass compass { get { return UnityEngine.Input.compass; } }
    public static DeviceOrientation deviceOrientation { get { return UnityEngine.Input.deviceOrientation; } }
    public static IMECompositionMode imeCompositionMode { get { return UnityEngine.Input.imeCompositionMode; } }
    public static string compositionString { get { return UnityEngine.Input.compositionString; } }
    public static bool imeIsSelected { get { return UnityEngine.Input.imeIsSelected; } }
    public static bool touchPressureSupported { get { return UnityEngine.Input.touchPressureSupported; } }
    public static Vector2 mouseScrollDelta { get { return UnityEngine.Input.mouseScrollDelta; } }
    public static Vector2 mousePosition { get { return UnityEngine.Input.mousePosition; } }
    public static Gyroscope gyro { get { return UnityEngine.Input.gyro; } }
    public static Vector2 compositionCursorPos { get { return UnityEngine.Input.compositionCursorPos; } }
    public static bool backButtonLeavesApp { get { return UnityEngine.Input.backButtonLeavesApp; } }
    [System.Obsolete("isGyroAvailable property is deprecated. Please use SystemInfo.supportsGyroscope instead.")]
    public static bool isGyroAvailable { get { return UnityEngine.Input.isGyroAvailable; } }
    public static bool compensateSensors { get { return UnityEngine.Input.compensateSensors; } }    
    public static AccelerationEvent GetAccelerationEvent(int index)
    {
        return UnityEngine.Input.GetAccelerationEvent(index);
    }
    public static float GetAxis(string axis)
    {
        //switch (mode)
        //{
        //case Mode.pc:
        //	return UnityEngine.Input.GetAxis (axis);
        //case Mode.touch:
        //	return GetAxisMobile(axis);
        //case Mode.both:
        return UnityEngine.Input.GetAxis(axis) + GetAxisMobile(axis);
        //default:
        //	return 0f;
        //}
    }
    public static float GetAxisRaw(string axis)
    {
        //switch (mode)
        //{
        //case Mode.pc:
        //	return UnityEngine.Input.GetAxisRaw (axis);
        //case Mode.touch:
        //	return GetAxisMobile(axis);
        //case Mode.both:
        return UnityEngine.Input.GetAxisRaw(axis) + GetAxisMobile(axis);
        //default:
        //	return 0f;
        //}
    }
    public static bool GetButton(string Button)
    {
        //switch (mode)
        //{
        //    case Mode.pc:
        //        return UnityEngine.Input.GetButton(Button);
        //    case Mode.touch:
        //        return GetButtonMobile(Button);
        //    case Mode.both:
        return UnityEngine.Input.GetButton(Button) || GetButtonMobile(Button);
        //    default:
        //        return false;
        //}
    }
    public static bool GetButtonDown(string Button)
    {
        //switch (mode)
        //{
        //    case Mode.pc:
        //        return UnityEngine.Input.GetButtonDown(Button);
        //    case Mode.touch:
        //        return GetButtonDownMobile(Button);
        //    case Mode.both:
        return UnityEngine.Input.GetButtonDown(Button) || GetButtonDownMobile(Button);
        //default:
        //    return false;
        // }
    }
    public static bool GetButtonUp(string Button)
    {
        //switch (mode)
        //{
        //    case Mode.pc:
        //        return UnityEngine.Input.GetButtonUp(Button);
        //    case Mode.touch:
        //        return GetButtonUpMobile(Button);
        //    case Mode.both:
        return UnityEngine.Input.GetButtonUp(Button) || GetButtonUpMobile(Button);
        //    default:
        //        return false;
        //}
    }
    public static string[] GetJoystickNames()
    {

        return UnityEngine.Input.GetJoystickNames();
    }
    public static bool GetKey(string key)
    {
        return UnityEngine.Input.GetKey(key);
    }
    public static bool GetKey(KeyCode key)
    {
        return UnityEngine.Input.GetKeyUp(key);
    }
    public static bool GetKeyDown(string key)
    {
        return UnityEngine.Input.GetKeyDown(key);
    }
    public static bool GetKeyDown(KeyCode key)
    {
        return UnityEngine.Input.GetKeyDown(key);
    }
    public static bool GetKeyUp(string key)
    {
        return UnityEngine.Input.GetKeyUp(key);
    }
    public static bool GetKeyUp(KeyCode key)
    {
        return UnityEngine.Input.GetKeyUp(key);
    }
    public static bool GetMouseButton(int button)
    {
        return UnityEngine.Input.GetMouseButton(button);
    }
    public static bool GetMouseButtonDown(int button)
    {
        return UnityEngine.Input.GetMouseButtonDown(button);
    }
    public static bool GetMouseButtonUp(int button)
    {
        return UnityEngine.Input.GetMouseButtonUp(button);
    }
    public static Touch GetTouch(int index)
    {
        return UnityEngine.Input.GetTouch(index);
    }

#if UNITY_STANDALONE_LINUX || UNITY_EDITOR
    public static bool IsJoystickPreconfigured(string joystickName)
    {

        return UnityEngine.Input.IsJoystickPreconfigured(joystickName);
    }
    public static void ResetInputAxes()
    {

        UnityEngine.Input.ResetInputAxes();

    }
#endif
    #endregion
    #region Debug
    //	void OnGUI(){
    //		if (!debug)
    //			return;
    //		
    //		GUILayout.Label ("----> Buttons Down");
    //		for (int i = 0; i < ButtonsDown.Count; i++) {
    //			GUILayout.Label (ButtonsDown [i]);
    //		}
    //		GUILayout.Label ("----> Buttons Hold");
    //		for (int i = 0; i < ButtonsHold.Count; i++) {
    //			GUILayout.Label (ButtonsHold [i]);
    //		}
    //		GUILayout.Label ("----> Buttons Up");
    //		for (int i = 0; i < ButtonsUp.Count; i++) {
    //			GUILayout.Label (ButtonsUp [i]);
    //		}
    //	}
    #endregion

    private static List<string> ButtonsDown = new List<string>();
    private static List<string> ButtonsHold = new List<string>();
    private static List<string> ButtonsUp = new List<string>();
    private static int lastFrameUpdated;
    public static bool GetButtonDownMobile(string name)
    {
        if (ButtonsDown.Contains(name))
        {
            if (Time.frameCount != lastFrameUpdated)
            {
                ButtonsDown.Clear();
                ButtonsUp.Clear();
                ButtonsHold.Clear();
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    public static string GetButtonDownList()
    {
        string txt = "";
        for (int i = 0; i < ButtonsDown.Count; i++)
        {
            txt += ButtonsDown[i]+"\n";
        }
        txt +="end";
        return txt;
    }
    public static bool GetButtonMobile(string name)
    {
        if (ButtonsHold.Contains(name))
        {
            if (Time.frameCount != lastFrameUpdated)
            {
                ButtonsDown.Clear();
                ButtonsUp.Clear();
                ButtonsHold.Clear();
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    public static bool GetButtonUpMobile(string name)
    {
        if (ButtonsUp.Contains(name))
        {
            if (Time.frameCount != lastFrameUpdated)
            {
                ButtonsDown.Clear();
                ButtonsUp.Clear();
                ButtonsHold.Clear();
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    public static void PressButtonDownMobile(string buttonName)
    {
        if (Time.frameCount != lastFrameUpdated)
        {
            ButtonsDown.Clear();
            ButtonsUp.Clear();
            ButtonsHold.Clear();
        }

        lastFrameUpdated = Time.frameCount;
        ButtonsDown.Add(buttonName);
    }
    public static void PressButtonMobile(string buttonName)
    {
        if (Time.frameCount != lastFrameUpdated)
        {
            ButtonsDown.Clear();
            ButtonsUp.Clear();
            ButtonsHold.Clear();
        }

        lastFrameUpdated = Time.frameCount;
        ButtonsHold.Add(buttonName);
    }
    public static void PressButtonUpMobile(string buttonName)
    {
        if (Time.frameCount != lastFrameUpdated)
        {
            ButtonsDown.Clear();
            ButtonsUp.Clear();
            ButtonsHold.Clear();
        }

        lastFrameUpdated = Time.frameCount;
        ButtonsUp.Add(buttonName);
    }
    public static float GetAxisMobile(string axisName)
    {
        if (MobileAxes == null || !MobileAxes.ContainsKey(axisName))
            return 0f;

        return MobileAxes[axisName];
    }
    private static IDictionary<string, float> MobileAxes = new Dictionary<string, float>();

    public static void SetAxisMobile(string Name, float value)
    {
        if(!MobileAxes.ContainsKey(Name))
            RegisterAxisMobile(Name);

        MobileAxes[Name] = value;
    }

    public static void RegisterAxisMobile(string Name)
    {
        if (MobileAxes.ContainsKey(Name))
            return;

        MobileAxes.Add(Name, 0f);
    }

}
