using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject burst;

    private void OnCollisionEnter(Collision collision)
    {        
        GameManager.instance.RemoveBlock();
        GameObject b = Instantiate(burst, transform.position, Quaternion.identity);

        Destroy(this.gameObject);      
    }
}
