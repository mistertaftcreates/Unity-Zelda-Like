using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float rollSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float latchedGroundSpeed;
    [SerializeField] private float latchedAirSpeed;
    [SerializeField] private Rigidbody myRigidbody;
    private Vector3 desiredVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        desiredVelocity.x = Input.GetAxisRaw("Horizontal");
        desiredVelocity.z = Input.GetAxisRaw("Vertical");
        desiredVelocity = Camera.main.transform.TransformDirection(desiredVelocity);
        desiredVelocity.y = 0;
        desiredVelocity = desiredVelocity.normalized * rollSpeed;
        if(Mathf.Abs(
            (myRigidbody.velocity - desiredVelocity).magnitude) 
            > 0.05f)
        {
            changeSpeed(desiredVelocity);
        }
    }

    void changeSpeed(Vector3 desiredSpeed)
    {
        myRigidbody.velocity = Vector3.Lerp(myRigidbody.velocity, desiredSpeed, Time.deltaTime);
    }
}
