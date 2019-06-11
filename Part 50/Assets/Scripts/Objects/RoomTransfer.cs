using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour {

    public Vector2 playerAdjust;
    public Vector2 cameraAdjust;
    public GameObject placeMarker;
    public Text placeText;
    public string placeName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            cam.minPosition += cameraAdjust;
            cam.maxPosition += cameraAdjust;
            player.transform.position += new Vector3(playerAdjust.x,
                                                     playerAdjust.y,
                                                    0);
            StartCoroutine(textCo());
        }
    }

    public IEnumerator textCo()
    {
        placeMarker.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4);
        placeMarker.SetActive(false);
    }
}
