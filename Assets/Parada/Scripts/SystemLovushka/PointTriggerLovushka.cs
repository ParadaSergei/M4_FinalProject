using UnityEngine;

public class PointTriggerLovushka : MonoBehaviour
{
    [SerializeField] private GameObject lovushkaKonecPrefab;
    private Ray rayRight;
    private Ray rayLeft;
    private RaycastHit hit;
    public bool isEmpty = true;
    public bool isActiveLovush1;
    public bool isActiveLovush2;


    private void Start()
    {
        isActiveLovush1 = false;
        isActiveLovush2 = false;
        rayRight = new Ray(transform.position, transform.right);
        rayLeft = new Ray(transform.position, -transform.right);
    }
    private void Update()
    {
        if (!isEmpty)
        {
            if (Physics.Raycast(transform.position, rayRight.direction, out hit, 10f))
            {
                if (hit.collider)
                {
                    if (!isActiveLovush1)
                    {
                        Instantiate(lovushkaKonecPrefab, hit.point, Quaternion.identity , transform);
                        isActiveLovush1 = true;
                    }
                }
            }
            if (Physics.Raycast(transform.position, rayLeft.direction, out hit, 10f))
            {
                if (hit.collider)
                {
                    if (!isActiveLovush2)
                    {
                        Instantiate(lovushkaKonecPrefab, hit.point, Quaternion.identity, transform);
                        isActiveLovush2 = true;
                    }
                }
            }
        }
    }
    /*private int InstantiateLovushkaKonecPrefab()
    {
        return 0;
    }*/
}
