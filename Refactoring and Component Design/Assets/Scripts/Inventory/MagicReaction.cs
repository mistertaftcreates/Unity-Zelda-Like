using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReaction : MonoBehaviour
{
    public FloatValue playerMagic;
    public Signal magicSignal;
    
    public void Use(int amountToIncrease)
    {
        playerMagic.RuntimeValue += amountToIncrease;
        magicSignal.Raise();
        Debug.Log("trying to add magic");
    }
}
