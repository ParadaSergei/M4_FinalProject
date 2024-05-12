using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "1" && Input.GetKey(KeyCode.Q)) //если объект сталкивается с объектом у которого есть тег "1" и клавиша "Q" нажата то 
        {

        }
    }       
}
