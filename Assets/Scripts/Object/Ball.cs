using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Ball : MonoBehaviour
{
    // === A: Properties === // 

    private static string logTag = typeof(Ball).Name;

    [Tooltip("Where to put the ball back on the table when lost")]
    public Vector3 startPosition;

    [Tooltip("Intensity of the force at which the ball is shot")]
    public float shootIntensity;

    [Tooltip("Intensity of the force at which the ball passed")]
    public float passIntensity;

    // The GameObject Rigidbody
    private Rigidbody mRigidBody;

    // Whether the ball is following a point (kinematic mode)
    private bool isFollowing;

    // === A: Objects === //

    // Object the ball follows (man)
    private GameObject previousCollidedObject;
    private GameObject followedObject;

    // Reference to the parent table
    private Transform table;

    
    // === F: Lifecycle === //

    void Start()
    {
        initialize();
    }

    private void initialize()
    {
       mRigidBody = GetComponent<Rigidbody>();
       isFollowing = false;
       table = transform.parent;
       previousCollidedObject = null;
       followedObject = null; 
    }

    void Update()
    {   

    }

    void OnCollisionEnter(Collision collision)
    {
        // Field doesn't count as collision
        if(collision.gameObject.tag != MyUtils.TAGS.FIELD)
        {
            // If we collide with NEW man, we follow it
            if(collision.gameObject.tag == MyUtils.TAGS.MAN &&
               collision.gameObject != previousCollidedObject)
            {
                StartFollowing(collision.gameObject);
            }

            // If table, bounce more
            if(collision.gameObject.tag == MyUtils.TAGS.TABLE)
            {
                GetComponent<Rigidbody>().AddForce(collision.impulse.normalized * passIntensity);
            }

            previousCollidedObject = collision.gameObject;
        }
    }


    // === F: Modifiers === //

    private void MakeKinematic()
    {
        mRigidBody.isKinematic = true;
    }

    private void MakeDynamic()
    {
        mRigidBody.isKinematic = false;
    }

    public void ResetPosition()
    {
        StopFollowing();
        MakeKinematic();

        transform.localPosition = startPosition;
        mRigidBody.velocity = Vector3.zero;
        previousCollidedObject = null;

        MakeDynamic();
    }

    private void StartFollowing(GameObject obj)
    {
        MakeKinematic();
        isFollowing = true;
        transform.parent = obj.transform;
        followedObject = obj;
    }

    public bool canBeMoved()
    {
        return isFollowing;
    }

    private void StopFollowing()
    {
        MakeDynamic();
        isFollowing = false;
        transform.parent = table;
        followedObject = null;
    }

    public void Shoot()
    {
        ShootTo(Vector3.forward, shootIntensity);
    }

    public void PassForward()
    {
        ShootTo(Vector3.forward, passIntensity);
    }

    public void PassBackward()
    {
        ShootTo(Vector3.forward * -1, passIntensity);
    }

    public void PassLeft()
    {
        ShootTo(Vector3.right * -1, passIntensity);
    }

    public void PassRight()
    {
        ShootTo(Vector3.right, passIntensity);
    }

    private void ShootTo(Vector3 direction, float intensity)
    {
        if(!isFollowing)
        {
            return;
        }

        // Compute force vector
        Row row = followedObject.transform.parent.GetComponent<Row>();
        Vector3 force = direction * intensity;

        if(row.rowColor == MyUtils.PlayerColor.BLUE)
        {
            force *= -1;
        }

        // Release ball and apply force
        StopFollowing();
        mRigidBody.AddForce(force);
    }
}