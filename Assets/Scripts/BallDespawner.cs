using System;
using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    public LayerMask ballLayer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & ballLayer) != 0)
        {
            Destroy(other.gameObject);   
        }
    }
}
