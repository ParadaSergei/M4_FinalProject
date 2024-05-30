using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyBETA : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform Player;
    public Vector3 Offset;
    public float Damage = 30;
    public float TrapDistanceVision = 0f;
    public float PlayerDistanceVision = 0f;

    private GameObject _trap;
    private NavMeshAgent _navMeshAgent;
    private Transform _trappos;
    private Vector3 _rayposition;
    private string _target;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _trap = GameObject.Find("LightStick");
        _rayposition = transform.position + Offset;
        CheckTrap();
        CheckPlayer();
        if (CheckTrap())
        {
            _navMeshAgent.SetDestination(_trappos.position);
            return;
        }

        if (CheckPlayer())
        {
            _navMeshAgent.SetDestination(Player.position);
        }
        else
        {
            Patrol();
        }
    }

    bool CheckTrap()
    {
        if (_trap != null)
        {
            _trappos = _trap.transform;
            Vector3 direction = _trap.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(_rayposition, direction, out hit, TrapDistanceVision))
            {
                if (hit.transform == _trappos)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    bool CheckPlayer()
    {
        /*Vector3 direction = Player.position - transform.position;

        RaycastHit hit;
        if (Physics.Raycast(_rayposition, direction, out hit, PlayerDistanceVision))
        {
            if (hit.transform == Player)
            {
                return true;
            }
        }*/
        if (Vector3.Distance(Player.position, transform.position) < 5)
        {
            return true;
        }
        return false;
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<HealthBarValue>().TakeDamage(30);
        }    
    }
}