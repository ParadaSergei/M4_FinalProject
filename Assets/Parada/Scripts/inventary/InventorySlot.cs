using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public  ItemScribtableObject item;
    public int amountItem;
    public bool isEmpty = true;
    public GameObject icon;
    public TMP_Text textAmountText;
    void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        textAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (amountItem == 0 || amountItem == 1)
        {
            textAmountText.enabled = false;
        }
        else 
        {
            textAmountText.enabled = true;
        }
    }

    public void SetIcon(Sprite _icons)
    {
        //dicon.GetComponent<Image>().color = new Color(1,1,1,1);
        icon.GetComponent<Image>().sprite = _icons;
    }
}
