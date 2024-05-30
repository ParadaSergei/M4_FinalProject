using UnityEngine;
using UnityEngine.AI;

public class HealthEnemy : MonoBehaviour
{
    public int health;
    [SerializeField] private GameObject prefabBoom;
    private void Start()
    {
        health = 100;
    }
    private void Update()
    {
        DieEnemy();
    }
    public void TakeDamage(int damage)
	{
        health -= damage;
	}
    private void DieEnemy()
    {
        if (health <= 0)
        {
            transform.GetComponent<AIEnemyBETA>().enabled = false;
            transform.GetComponent<NavMeshAgent>().enabled = false;
            Instantiate(prefabBoom, transform.position, Quaternion.identity);
            Invoke("destroyEnemy", 2);
        }
    }
    private void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
