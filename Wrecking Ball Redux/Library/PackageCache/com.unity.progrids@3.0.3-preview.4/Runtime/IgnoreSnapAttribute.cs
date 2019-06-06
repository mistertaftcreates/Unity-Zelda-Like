using System;

namespace UnityEngine.ProGrids
{
	/// <summary>
	/// Apply this attribute to a MonoBehaviour to disable grid snapping on the parent object.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ProGridsNoSnapAttribute : Attribute
	{
	}

	/// <summary>
	/// Tells ProGrids to check for a function named `bool IsSnapEnabled()` on this object. In this way you can
	/// programmatically enable or disable snapping.
	/// </summary>
	[Obsolete("Use IConditionalSnap interface")]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ProGridsConditionalSnapAttribute : Attribute
	{
	}

	/// <summary>
	/// Implement this interface in a MonoBehaviour to dynamically enable or disabled grid snapping on the parent
	/// GameObject.
	/// </summary>
	public interface IConditionalSnap
	{
		bool snapEnabled { get; }
	}
}
