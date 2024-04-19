using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldSlot : MonoBehaviour
{
    public Sprite notSelectedSprite;
    public InventorySlot oldSlot;
    void Start()
    {
        oldSlot = transform.GetComponentInParent<InventorySlot>();
    }
    public void NullifySlotData()
    {
        oldSlot.item = null;
        oldSlot.amountItem = 0;
        oldSlot.isEmpty = true;
        oldSlot.icon.GetComponent<Image>().sprite = notSelectedSprite;
        oldSlot.textAmountText.text = "";

    }

}
