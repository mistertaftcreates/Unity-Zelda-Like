using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public pot[] pots;
    public ResetToPosition[] objectsToReset;
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies and pots
            for(int i = 0; i < enemies.Length; i ++)
            {
                ChangeActivation(enemies[i], true);
            }
            for(int i = 0; i < pots.Length; i ++)
            {
                ChangeActivation(pots[i], true);
            }
            virtualCamera.SetActive(true);
            for(int i = 0; i < objectsToReset.Length; i ++)
            {
                objectsToReset[i].ResetPosition();
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies and pots
            //Activate all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
            virtualCamera.SetActive(false);
            for (int i = 0; i < objectsToReset.Length; i++)
            {
                objectsToReset[i].ResetPosition();
            }
        }
    }

    public void OnDisable()
    {
        virtualCamera.SetActive(false);
    }

    public void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
