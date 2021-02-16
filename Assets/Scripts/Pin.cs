using System;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class Pin : MonoBehaviour
{
    public LayerMask collisionLayer;
    
    public event Action<Pin> PinDestroyEvent;

    private void OnCollisionEnter(Collision other)
    {
        if (((1 << other.gameObject.layer) & collisionLayer) != 0)
        {
            StartCoroutine(AddPointAndDestroy());
        }
    }

    private IEnumerator AddPointAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        
        GameplayController.AddPoint();
        
        PinDestroyEvent?.Invoke(this);
        
        Destroy(gameObject);   
    }
}
