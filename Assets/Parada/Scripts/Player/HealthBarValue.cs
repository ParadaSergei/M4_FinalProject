using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarValue : MonoBehaviour
{
    public int healthValue;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject prefabElectric;
    private void Update()
    {
        healthSlider.value = healthValue;
    }
    public void TakeDamage(int damage)
    {
        healthValue -= damage;
        Instantiate(prefabElectric, transform.position, Quaternion.identity);
    }
}
