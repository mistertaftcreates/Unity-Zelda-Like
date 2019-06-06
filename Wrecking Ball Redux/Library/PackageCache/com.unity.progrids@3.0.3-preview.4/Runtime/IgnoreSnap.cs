using UnityEngine;

namespace UnityEngine.ProGrids
{
	/// <summary>
	/// Assign this script to a GameObject to tell ProGrids to ignore snapping on this object. Child objects are still subject to snapping.
	/// </summary>
	[ProGridsNoSnap]
	public class IgnoreSnap : MonoBehaviour {}
}
