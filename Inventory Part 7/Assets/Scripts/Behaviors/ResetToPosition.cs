using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToPosition : MonoBehaviour
{

    [SerializeField] private Vector3 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        transform.position = homePosition;
    }

}
