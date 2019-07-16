using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LeoLuz.PropertyAttributes
{
	/// <summary>
	/// Large header attribute for Editor.
	/// </summary>
	public class LargeHeader : PropertyAttribute  {

		public string name;
		public string color = "white";
        public int Size;

        public LargeHeader (string name, string _color = "cyan", int size = 17) {
			this.name = name;
			this.color = _color;
            this.Size = size;
        }
	}

    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(LargeHeader))]
    public class LargeHeaderDrawer : DecoratorDrawer
    {
        // Used to calculate the height of the box
        public static Texture2D lineTex = null;
        private GUIStyle style;

        LargeHeader largeHeader { get { return ((LargeHeader)attribute); } }

        // Get the height of the element
        public override float GetHeight()
        {
            return base.GetHeight() * 2f;
        }


        // Override the GUI drawing for this attribute
        public override void OnGUI(Rect pos)
        {
            // Get the color the line should be
            Color color = Color.white;

            switch (largeHeader.color.ToString().ToLower())
            {
                case "white": color = Color.white; break;
                case "red": color = Color.red; break;
                case "blue": color = Color.blue; break;

                case "green": color = Color.green; break;
                case "gray": color = Color.gray; break;
                case "grey": color = Color.grey; break;
                case "black": color = Color.black; break;
                case "yellow": color = Color.yellow; break;
                case "cyan": color = Color.cyan; break;
                case "bluegreen":
                    Vector4 v = Color.blue;
                    v += (Vector4)Color.green;
                    v = v / 2f;
                    color = v; break;
                case "yellowgreen":
                    Vector4 v2 = Color.yellow;
                    v2 += (Vector4)Color.green;
                    v2 = v2 / 2f;
                    color = v2; break;
                case "redblue":
                    Vector4 v3 = Color.blue;
                    v3 += (Vector4)Color.red;
                    v3 = v3 / 1.3f;
                    color = v3; break;
                case "orange":
                    Vector4 v4 = Color.yellow;
                    v4 += (Vector4)Color.red;
                    v4 = v4 / 2f;
                    color = v4; break;
                case "babyblue":
                    Vector4 v5 = Color.white;
                    v5 += (Vector4)Color.blue;
                    v5 = v5 / 2f;
                    color = v5; break;
            }

            Vector4 s = Color.white;
            style = new GUIStyle(GUI.skin.label);
            style.fontSize = largeHeader.Size;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.LowerLeft;
            GUI.color = color;

            Rect labelRect = pos;
            //labelRect.y += 10;
            EditorGUI.LabelField(labelRect, largeHeader.name, style);

            GUI.color = Color.white;
        }
    }
    #endif
}
