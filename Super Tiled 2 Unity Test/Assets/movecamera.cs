using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(
            Input.GetAxisRaw("Horizontal") * 5 * Time.deltaTime,
            Input.GetAxisRaw("Vertical") * 5 * Time.deltaTime);
        movement = movement.normalized * 5 * Time.deltaTime;
        transform.position = transform.position + new Vector3(movement.x,
            movement.y, 0);
    }
}
