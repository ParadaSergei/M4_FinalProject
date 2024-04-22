using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CameraRayCast : MonoBehaviour
{
  
    public float _distanceHit = 2;

    private RaycastHit hit;
    private Ray ray;
    [SerializeField] private Inventorymanager manager;
    public bool keyInHands = false;
    public float sensitivitySpeed = 2;

    [SerializeField] private GameObject gameObject;

    void Start()
    {
       
       /* sensitivitySpeed = PlayerPrefs.GetFloat("SensitivitySettings");
        Cursor.lockState = CursorLockMode.Locked;*/
    }

    void Update()
    {
       
        

       /* int languageSetingsValue = PlayerPrefs.GetInt("languageSetingsValue");

        float newAngle = mainCamera.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * sensitivitySpeed;
        if (newAngle > 180)
        {
            newAngle = newAngle - 360;
        }
        newAngle = Mathf.Clamp(newAngle, -80, 80);
        mainCamera.transform.rotation = Quaternion.Euler(newAngle, mainCamera.transform.rotation.eulerAngles.y, mainCamera.transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivitySpeed, transform.rotation.eulerAngles.z);
        ray = mainCamera.ScreenPointToRay(Input.mousePosition); 
        positionCamera = mainCamera.transform.position;
        moveTransformCamera = mainCamera.transform.forward;
        if ((Physics.Raycast(positionCamera, moveTransformCamera, out hit, _distanceHit)))
        {
            *//*if (hit.collider.CompareTag("Action"))
            {
                _activeCursor.SetActive(true);
            }*//*
        }*/
        /* if (Input.GetKeyUp(KeyCode.E))
         {
             if (Physics.Raycast(positionCamera, moveTransformCamera, out hit, _distanceHit) || Physics.Raycast(ray, out hit, _distanceHit))
             {
                 if (hit.collider.gameObject.GetComponent<Item>() != null)
                 {
                     manager.AddItem(hit.collider.gameObject.GetComponent<Item>().itemItem, hit.collider.gameObject.GetComponent<Item>().amountItem);
                     Destroy(hit.collider.gameObject);
                 }
             }
         }*/
    }
}
