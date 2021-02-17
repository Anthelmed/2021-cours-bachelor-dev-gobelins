using System;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class Pin : MonoBehaviour
{
    public LayerMask collisionLayer;
    
    public event Action<Pin> PinDestroyEvent;

    private bool _checkCollision = true;

    private void OnCollisionEnter(Collision other)
    {
        if (!_checkCollision) return;
        
        if (((1 << other.gameObject.layer) & collisionLayer) != 0)
        {
            _checkCollision = false;
            
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
