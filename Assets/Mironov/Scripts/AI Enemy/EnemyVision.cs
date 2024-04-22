using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public GameObject _prioritet;
    public int rays = 8;
    public float angle = 40;
    public Vector3 offset;
    private NavMeshAgent _nana;
    private float _targetforce = 5f;
    private float distance = 999999f;

    void Start()
    {
        _nana = GetComponent<NavMeshAgent>();
        _nana.enabled = true;
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform.GetComponent<LightHaracteristics>().Light == true)
            {
                if (hit.transform.GetComponent<LightHaracteristics>().ForceLight >= _targetforce)
                {
                    result = true;
                    _prioritet = hit.transform.gameObject;
                    _targetforce = hit.transform.GetComponent<LightHaracteristics>().ForceLight;
                }

            }
        }
        Debug.DrawLine(pos, hit.point, Color.green);
        Debug.DrawLine(pos, hit.point, Color.blue);
        Debug.DrawRay(pos, dir * distance, Color.red);
        return result;
    }
    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }
        if (a || b) result = true;
        return result;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _prioritet.transform.position) < _targetforce)
        {
            if (RayToScan())
            {
               // _nana.enabled = true;
            }
        }
        else
        {
            Patrol();
        }
    }
    void Patrol()
    {
        if (_nana.remainingDistance <= _nana.stoppingDistance)
        {
            _nana.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }
}