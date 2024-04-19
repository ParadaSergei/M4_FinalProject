using UnityEngine;
using UnityEngine.SceneManagement;


public class FPSController : MonoBehaviour
{
    [SerializeField] public GameObject _panelMenu;
    [SerializeField] private GameObject inventory;
    public bool Activepanelmenu;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 5;
    [SerializeField] private float _movementSpeed = 2;
    [SerializeField] private Animator animationPlayerCamera;
    [SerializeField] private AudioSource dihanieSpokoinoe;
    [SerializeField] public AudioSource shag;
    [SerializeField] public CameraRayCast cameraRayCast;
   
    void Start()
    {
        _panelMenu.SetActive(false);
        rig = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivePanel();
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            shag.Play();
        }
        else
        {
            dihanieSpokoinoe.Play();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = 20f;
        }
        else
        {
            _movementSpeed = speed;
        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 cameraForward = mainCamera.forward;
        cameraForward.y = 0;
        Vector3 cameraRightDir = mainCamera.right;
        Vector3 movementDiraction = cameraForward.normalized * vertical + cameraRightDir.normalized * horizontal;
        movementDiraction = Vector3.ClampMagnitude(movementDiraction, 1) * _movementSpeed;
        rig.velocity = new Vector3(movementDiraction.x, rig.velocity.y, movementDiraction.z);
        rig.angularVelocity = new Vector3(0, 0, 0);
    }
    public void ActivePanel()
    {
        Activepanelmenu = !Activepanelmenu;
        if (Activepanelmenu)
        {
            _panelMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cameraRayCast.enabled = false;
            Time.timeScale = 0f;
            dihanieSpokoinoe.Stop();
            shag.Stop();
        }
        else
        {
            _panelMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cameraRayCast.enabled = true;
            Time.timeScale = 1f;
            dihanieSpokoinoe.Play();
            shag.Play();
        }
    }
}
