using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Slider sliderRasudok;
    public float rasudokAmount;
    public float firstAidKitValue = 50; //запас здоровья которое может востановит аптечка

    bool collided;

    private void Update()
    {
        sliderRasudok.value = rasudokAmount;
        if (rasudokAmount < 0)
        {
            SceneManager.LoadScene("StoryBadEnd");
        }
        if (Input.GetKey(KeyCode.Space) && collided == true) //если объект сталкивается с объектом у которого есть тег "1" и клавиша "Q" нажата то  
        {
            if (firstAidKitValue > 0) //проверка на оставшийся запас аптечки
            {
                if (rasudokAmount < 100)
                {
                    rasudokAmount++;  //увеличиваем здоровье на 1
                    firstAidKitValue--;  //уменьшаем запас аптечки на 1
                }
            }
            if (firstAidKitValue <= 0)             //удаляем аптечку если у нее закончился запас
            {
                var objs = GameObject.FindGameObjectsWithTag("1"); //ищем все объекты с тегом 1
                for (int i = 0; i < objs.Length; i++)  //перебираем их в цикле и удаляем
                {
                    Destroy(objs[i]);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)  //при косании в collided записывается о том что косание произошло
    {
        if (collision.gameObject.tag == "1")
        {
            collided = true;
        }

    }
    void OnCollisionExit(Collision collision)  //когда косание перестается это записывается в collided
    {
        if (collision.gameObject.tag == "1")
        {
            collided = false;
        }
    }
}
