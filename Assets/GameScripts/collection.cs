using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
}
