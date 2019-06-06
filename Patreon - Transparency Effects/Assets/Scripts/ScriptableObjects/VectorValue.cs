using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver {

    [Header("Value running in game")]
    public Vector2 initialValue;
    [Header("Value by default when starting")]
    public Vector2 defaultValue;

    public void OnAfterDeserialize() { initialValue = defaultValue; }

    public void OnBeforeSerialize(){}

}
