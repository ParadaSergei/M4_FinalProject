using UnityEngine;

public class LightStickDrop : MonoBehaviour
{
    [SerializeField] private Transform _pricelCursor;
    [SerializeField] private GameObject _stickPrefab;
    [SerializeField] private GameObject _lightFonar;

    private float forceStick = 100;

    void Update()
    {
        /*if (forceStick > 1000)
        {
            forceStick = 1000;
        }
        if (Input.GetKey(KeyCode.G))
        {
            forceStick += 5;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            var __stickPrefabRig = Instantiate(_stickPrefab, transform.position, transform.rotation);
            __stickPrefabRig.GetComponent<Rigidbody>().AddForce(transform.forward * forceStick);
            forceStick = 500;
        }*/
    }
    private void LateUpdate()
    {
        transform.LookAt(_pricelCursor.position); 
    }
}
