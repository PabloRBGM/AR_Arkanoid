using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float initialForce;
    Rigidbody rb;
    Vector3 startPosition;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("RigidBody missing");
    }
    private void Start()
    {
        startPosition = transform.position;
    }
    public void AddInitialForce()
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, initialForce));
    }

    public void Reset()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
