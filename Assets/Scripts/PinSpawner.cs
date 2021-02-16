using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private GameObject[] pinOrigins;

    private int _activePin = 0;
    
    private void Awake()
    {
        SpawnPins();
    }

    private void SpawnPins()
    {
        foreach (var pinOrigin in pinOrigins)
        {
            var position = pinOrigin.transform.position;
            var rotation = Quaternion.identity;
            
            var pinGameObject = Instantiate(pinPrefab, position, rotation);
            var pin = pinGameObject.GetComponent<Pin>();
            
            pin.PinDestroyEvent += OnPinDestroyed;
            
            _activePin++;
        }
    }

    private void OnPinDestroyed(Pin pin)
    {
        pin.PinDestroyEvent -= OnPinDestroyed;
        
        _activePin--;
        
        if (_activePin == 0)
            SpawnPins();
    }
}
