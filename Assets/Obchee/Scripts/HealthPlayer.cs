using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource healthAudio;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<HealthBarValue>())
            {
                healthAudio.Play();
                other.GetComponent<HealthBarValue>().TakeHealth(100);
                Destroy(transform.gameObject);
            }
        }

    }
}
