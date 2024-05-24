using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Slider sliderRasudok;
    public float rasudokAmount;
    public float firstAidKitValue = 50; //����� �������� ������� ����� ���������� �������

    bool collided;

    private void Update()
    {
        sliderRasudok.value = rasudokAmount;
        if (rasudokAmount < 0)
        {
            SceneManager.LoadScene("StoryBadEnd");
        }
        if (Input.GetKey(KeyCode.Space) && collided == true) //���� ������ ������������ � �������� � �������� ���� ��� "1" � ������� "Q" ������ ��  
        {
            if (firstAidKitValue > 0) //�������� �� ���������� ����� �������
            {
                if (rasudokAmount < 100)
                {
                    rasudokAmount++;  //����������� �������� �� 1
                    firstAidKitValue--;  //��������� ����� ������� �� 1
                }
            }
            if (firstAidKitValue <= 0)             //������� ������� ���� � ��� ���������� �����
            {
                var objs = GameObject.FindGameObjectsWithTag("1"); //���� ��� ������� � ����� 1
                for (int i = 0; i < objs.Length; i++)  //���������� �� � ����� � �������
                {
                    Destroy(objs[i]);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)  //��� ������� � collided ������������ � ��� ��� ������� ���������
    {
        if (collision.gameObject.tag == "1")
        {
            collided = true;
        }

    }
    void OnCollisionExit(Collision collision)  //����� ������� ����������� ��� ������������ � collided
    {
        if (collision.gameObject.tag == "1")
        {
            collided = false;
        }
    }
}
