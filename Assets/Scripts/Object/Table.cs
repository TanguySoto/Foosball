using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    // === A: Properties === //

    private static string logTag = typeof(Table).Name;


    // === F: Lifecycle === //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == MyUtils.TAGS.BALL)
        {
            // bounces toward middle of the table
            if(collision.impulse == Vector3.zero)
            {
                Vector3 bounceForce = transform.position - collision.gameObject.transform.position;
                bounceForce = new Vector3(bounceForce.x, 0, bounceForce.z);
                bounceForce = bounceForce.normalized;
                bounceForce *= collision.gameObject.GetComponent<Ball>().passIntensity;

                collision.gameObject.GetComponent<Rigidbody>().AddForce(bounceForce);
            }
        }
    }
}
