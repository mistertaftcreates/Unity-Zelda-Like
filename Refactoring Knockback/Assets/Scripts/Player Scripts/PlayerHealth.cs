using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private Signal healthSignal;
    // Start is called before the first frame update

    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        maxHealth.RuntimeValue = currentHealth;
        healthSignal.Raise();
    }
}
