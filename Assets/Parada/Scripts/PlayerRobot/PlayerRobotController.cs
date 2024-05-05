using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobotController : MonoBehaviour
{
    [SerializeField]private GameObject _allbody;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _allbody.transform.parent = transform.GetChild(0);
            //transform.Rotate(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _allbody.transform.parent = transform.GetChild(1);
            //transform.Rotate(0, -1, 0);
        }
        else
        {
            _allbody.transform.parent = transform.GetChild(2);
        }
        
    }
}
