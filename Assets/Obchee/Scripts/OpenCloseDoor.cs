using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    public bool _isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isOpen = !_isOpen;
        }
        if (_isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -3, transform.position.z), Time.deltaTime/2 );
        }
        else if(!_isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 4, transform.position.z), Time.deltaTime / 2);
        }
    }
}
