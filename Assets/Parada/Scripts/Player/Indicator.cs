using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Slider sliderRasudok;
    public float rasudokAmount;

    private void Update()
    {
        sliderRasudok.value = rasudokAmount;
        if (rasudokAmount < 0)
        {
            SceneManager.LoadScene("StoryBadEnd");
        }
    }
}
