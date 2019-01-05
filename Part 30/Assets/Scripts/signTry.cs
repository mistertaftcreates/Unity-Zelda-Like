using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signTry : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool showDialog;
    public bool playerInRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            ShowDialog();
        }
	}

    private void ShowDialog()
    {
        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }else{
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(!playerInRange)
            {
                other.GetComponent<emotionTry>().Question();
                playerInRange = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
            playerInRange = false;
            other.GetComponent<emotionTry>().Question();
        }
    }
}
