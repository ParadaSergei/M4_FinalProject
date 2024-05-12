using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHP : MonoBehaviour
{
    public float HP = 10f;
    public float HPToLerpCof = 10f;
    public float MaxLightRange;

    private Light LightController;
    private float _hplerp;

    void Start()
    {
        LightController = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        //Переводим значения из X -> 0 на 1 -> 0
        _hplerp = HP / HPToLerpCof;

        LightController.range = Mathf.Lerp(0, MaxLightRange, _hplerp);
    }
}
