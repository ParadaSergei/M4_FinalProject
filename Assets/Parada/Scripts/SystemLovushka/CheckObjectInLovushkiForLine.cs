using UnityEngine;

public class CheckObjectInLovushkiForLine : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private PointTriggerLovushka pointTriggerLovushkaScripts;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        pointTriggerLovushkaScripts = GetComponent<PointTriggerLovushka>();
    }
    void Update()
    {
        if (!pointTriggerLovushkaScripts.isEmpty)
        {
            if (transform.childCount >= 2 && transform.GetChild(0) != null && transform.GetChild(1) != null)
            {
                line.SetPosition(0, transform.GetChild(0).gameObject.transform.position);
                line.SetPosition(1, transform.GetChild(1).gameObject.transform.position);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pointTriggerLovushkaScripts.isEmpty == false)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (other.GetComponent<HealthEnemy>())
                {
                    other.GetComponent<HealthEnemy>().TakeDamage(120);
                    Destroy(transform.gameObject);
                }
            }
        }
    }
}
