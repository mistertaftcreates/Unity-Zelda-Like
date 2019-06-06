using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (SphereCollider))]
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Rigidbody myRigidbody;
    private Vector3 movementVector = Vector3.zero;
    [SerializeField] private Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal") + myCamera.transform.position.x;
        movementVector.z = Input.GetAxisRaw("Vertical") + myCamera.transform.position.z;
        movementVector = Camera.main.transform.TransformDirection(movementVector);
        movementVector.y = 0;
        myRigidbody.velocity = (movementVector.normalized * speed);
        Debug.Log(myRigidbody.velocity);
    }
}
