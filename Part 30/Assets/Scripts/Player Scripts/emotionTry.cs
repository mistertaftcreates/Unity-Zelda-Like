using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotionTry : MonoBehaviour {

    public GameObject questionBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Question()
    {
        if (!questionBox.activeInHierarchy)
        {
            questionBox.SetActive(true);
        }else{
            questionBox.SetActive(false);
        }
    }
}
