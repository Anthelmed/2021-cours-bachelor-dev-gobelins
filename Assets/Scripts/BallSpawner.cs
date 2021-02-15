using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject spawnOrigin;
    [Range(0f, 500f)] [SerializeField] private float force = 100f;
    [Range(0f, 500f)] [SerializeField] private float torque = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = spawnOrigin.transform.position;
            var rotation = Quaternion.identity;
            
            var ball = Instantiate(ballPrefab, position, rotation);
            var rigidbody = ball.GetComponent<Rigidbody>();
            
            rigidbody.AddForce(spawnOrigin.transform.forward * force, ForceMode.Impulse);
            rigidbody.AddTorque(spawnOrigin.transform.forward * torque, ForceMode.Impulse);
        }
    }
}