using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private OpenCloseDoor openCloseDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stick"))
        {
            Debug.Log("YES!!!");
            openCloseDoor._isOpen = true;
        }
    }
}
