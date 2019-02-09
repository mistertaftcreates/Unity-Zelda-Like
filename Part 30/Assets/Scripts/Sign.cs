using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    public Signal contextOn;
    public Signal contextOff;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
