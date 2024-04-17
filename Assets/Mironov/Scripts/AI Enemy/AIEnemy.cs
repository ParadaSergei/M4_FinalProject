using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform Player;
    public float Damage = 30;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {


        CheckPlayer();
        if (CheckPlayer())
        {
            _navMeshAgent.SetDestination(Player.position);
        }
        else
        {
            Patrol();
        }
        AttackUpdate();
    }

    bool CheckPlayer()
    {
        var direction = Player.position - transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform == Player)
            {
                return true;
            }
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
    void AttackUpdate()
    {
        if (CheckPlayer())
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                //Player.GetComponent<PlayerHP>().DealDamage(Damage * Time.deltaTime);
            }
        }
    }
}
