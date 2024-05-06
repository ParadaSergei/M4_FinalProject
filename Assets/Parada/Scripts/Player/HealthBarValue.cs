using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarValue : MonoBehaviour
{
    public int healthValue;
    [SerializeField] private Slider healthSlider;
    private void Update()
    {
        healthSlider.value = healthValue;
    }
}
