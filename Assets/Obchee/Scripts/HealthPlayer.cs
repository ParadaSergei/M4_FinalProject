using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<HealthBarValue>())
            {
                other.GetComponent<HealthBarValue>().TakeHealth(50);
                Destroy(transform.gameObject);
            }
        }

    }
}
