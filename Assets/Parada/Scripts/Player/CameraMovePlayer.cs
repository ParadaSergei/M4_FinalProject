using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovePlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _pricelPosition;


    void Update()
    {
        if(Input.GetKey(KeyCode.C)) ZoomPricel(); 
        else TransformCamera();
    }
    public void TransformCamera() => transform.position = new Vector3(_playerPosition.position.x , _playerPosition.position.y + 8 , _playerPosition.position.z);
    private void ZoomPricel()
    {
        transform.position = new Vector3(_pricelPosition.position.x, _pricelPosition.position.y + 8 , _pricelPosition.position.z);
    }
}
