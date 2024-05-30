using UnityEngine;

public class CheckObjectInLovushkiForLine : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    private PointTriggerLovushka pointTriggerLovushkaScripts;
    private bool _isNoEmpty = false;
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
}
