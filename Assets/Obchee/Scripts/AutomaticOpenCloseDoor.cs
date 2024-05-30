using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticOpenCloseDoor : MonoBehaviour
{
    [SerializeField] private OpenCloseDoor openCloseDoor;
    private void Start()
    {
        openCloseDoor = GetComponent<OpenCloseDoor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openCloseDoor._isOpen = true;
        }
    }
   /* private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openCloseDoor._isOpen = false;
        }
    }*/
}
