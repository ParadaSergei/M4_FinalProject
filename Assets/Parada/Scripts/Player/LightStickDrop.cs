using UnityEngine;

public class LightStickDrop : MonoBehaviour
{
    [SerializeField] private Transform _pricelCursor;
    [SerializeField] private GameObject _stickPrefab;
    [SerializeField] private GameObject _lightFonar;

    private float forceStick = 100;
    private void LateUpdate()
    {
        transform.LookAt(_pricelCursor.position); 
    }
}
