using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotUpdateNoga : MonoBehaviour
{
    [SerializeField] private Transform _nogaLeftPoint;
    [SerializeField] private Transform _nogaRightPoint;
    [SerializeField] private Transform _positionPivotLeft;
    [SerializeField] private Transform _positionPivotRight;
    [SerializeField] private AudioSource movePlayer;
    //public byte NogaTransorm;
    private byte NogaBool;

    void Update()
    {
        /*_positionPivotRight = new Vector3(_noga.position.x , _noga.position.y - 0.5f, _noga.position.z);
        if (NogaTransorm == 0)  transform.position = _positionPivotLeft;
        if (NogaTransorm == 1) transform.position = _positionPivotRight;*/

        /* _positionPivotLeft = new Vector3(_noga.position.x, _noga.position.y - 0.5f, _noga.position.z);
         _positionPivotRight = new Vector3(_noga.position.x, _noga.position.y - 0.5f, _noga.position.z);*/

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) movePlayer.Play();

        if (Input.GetKey(KeyCode.A))
        {
           //ResetRotation();
            NogaBool = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //ResetRotation();
            NogaBool = 1;
        }
        else if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.D)) NogaBool = 2;
    }
    private void FixedUpdate()
    {
        _nogaLeftPoint.position = new Vector3(_positionPivotLeft.position.x , _positionPivotLeft.position.y - 0.5f, _positionPivotLeft.position.z);
        _nogaRightPoint.position = new Vector3(_positionPivotRight.position.x, _positionPivotRight.position.y - 0.5f, _positionPivotRight.position.z);

        if (NogaBool == 0) _nogaLeftPoint.Rotate(0, -4f, 0);
        else if (NogaBool == 1) _nogaRightPoint.Rotate(0, 4f, 0);
        else
        {
            _nogaLeftPoint.Rotate(0, 0, 0);
            _nogaRightPoint.Rotate(0, 0, 0);

        }
    }
    private void ResetRotation()=> transform.rotation = Quaternion.Euler(0, 0, 0);
}
