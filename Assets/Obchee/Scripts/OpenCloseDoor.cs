using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    public bool _isOpen = false;
    [SerializeField] private AudioSource openDoorAudio;

    void Update()
    {
        if (_isOpen)
        {
            openDoorAudio.Play() ;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -5, transform.position.z), Time.deltaTime*3 );
        }
        else if(!_isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 3, transform.position.z), Time.deltaTime * 3);
        }
    }
}
