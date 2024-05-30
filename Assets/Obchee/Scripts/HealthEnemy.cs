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
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lovushka"))
        {
            Debug.Log("Есть контакт!!!!!!!!!");
            if (other.gameObject.GetComponent<PointTriggerLovushka>().isEmpty == false)
            {
                health -= 120;
            }
        }
    }*/
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
