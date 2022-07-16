using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    public float strength;
    private void OnCollisionEnter(Collision other)
    {        
        ContactPoint p = other.GetContact(0);
        Vector3 dir = p.point - transform.position;
        Rigidbody oRB = other.gameObject.GetComponent<Rigidbody>();
        oRB.velocity = Vector3.zero;
        oRB.AddForce(dir.normalized * strength * 1.01f);
    }
}
