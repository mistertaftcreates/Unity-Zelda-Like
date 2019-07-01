using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [Header("Current Health and Signal")]
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private FloatValue maxHeartContainers;
    [SerializeField] private Signal healthSignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        if (currentHealth && maxHeartContainers && healthSignal)
        {
            currentHealth.RuntimeValue -= damageToTake;
            if (currentHealth.RuntimeValue <= 0)
            {
                currentHealth.RuntimeValue = 0;
            }
            healthSignal.Raise();
        }
    }

    public void Kill()
    {
        if (currentHealth && maxHeartContainers && healthSignal)
        {
            currentHealth.RuntimeValue = 0;
            healthSignal.Raise();
        }
    }

    public void Heal(float amountToHeal)
    {
        if (currentHealth && maxHeartContainers && healthSignal)
        {
            currentHealth.RuntimeValue += amountToHeal;
            if (currentHealth.RuntimeValue > maxHeartContainers.RuntimeValue * 2)
            {
                currentHealth.RuntimeValue = maxHeartContainers.RuntimeValue * 2;
            }
            healthSignal.Raise();
        }
    }

    public void FullHeal()
    {
        if (currentHealth && maxHeartContainers && healthSignal)
        {
            currentHealth.RuntimeValue = maxHeartContainers.RuntimeValue * 2;
            healthSignal.Raise();
        }
    }
}
