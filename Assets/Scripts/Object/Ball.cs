using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPosition;

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
        // bad as ball is non-kinematic rigidbody
        transform.localPosition = startPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
