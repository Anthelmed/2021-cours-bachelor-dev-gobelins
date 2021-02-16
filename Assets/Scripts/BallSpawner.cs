using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [Header("Ball properties")]
    public GameObject ballPrefab;
    [SerializeField] private Vector2 minMaxForce = new Vector2(75, 100); //Best practice for visible variable inside the editor
    [SerializeField] private Vector2 minMaxTorque = new Vector2(-1, 1);
    
    [Header("Origin properties")]
    public GameObject spawnOrigin;
    [SerializeField] private Vector2 minMaxPosition = Vector2.zero;
    
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hit))
        {
            var position = spawnOrigin.transform.position;

            //Cas ou votre valeur x change de gauche à droite
            
            var x = Mathf.Clamp(hit.point.x, minMaxPosition.x, minMaxPosition.y);
            spawnOrigin.transform.position = new Vector3( x, position.y, position.z);
            
            //Cas ou votre valeur z change de gauche à droite
            
            //var z = Mathf.Clamp(hit.point.z, minMaxPosition.x, minMaxPosition.y);
            //spawnOrigin.transform.position = new Vector3( position.x, position.y, z);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            var position = spawnOrigin.transform.position;
            var rotation = Quaternion.identity;
            
            var ball = Instantiate(ballPrefab, position, rotation);
            var rigidbody = ball.GetComponent<Rigidbody>();

            var randomForce = minMaxForce.RandomRange(); //Use Vector 2 Extension
            var randomTorque = Random.Range(minMaxTorque.x, minMaxTorque.y);
            
            rigidbody.AddForce(spawnOrigin.transform.forward * randomForce, ForceMode.Impulse);
            rigidbody.AddTorque(spawnOrigin.transform.forward * randomTorque, ForceMode.Impulse);
        }
    }
}