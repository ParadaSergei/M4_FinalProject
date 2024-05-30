using UnityEngine;

public class CheckEnemyLovushka : MonoBehaviour
{
    private PointTriggerLovushka pointTriggerLovushka;

    private void Start()
    {
        pointTriggerLovushka = GetComponent<PointTriggerLovushka>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pointTriggerLovushka.isEmpty == false)
        {
            Debug.Log("Есть контакт!!!!!!!!!");
            if (other.gameObject.GetComponent<HealthEnemy>() != null)
            {
                other.gameObject.GetComponent<HealthEnemy>().health -= 120;
            }
        }
    }
}
