using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventorymanager : MonoBehaviour
{
    public Transform panelInventary;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    void Start()
    {

        for (int i = 0; i < panelInventary.childCount; i++) //добавления слотов в лист
        {
            if (panelInventary.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                inventorySlots.Add(panelInventary.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }


    public void AddItem(ItemScribtableObject _item , int _amount)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            // слоте уже имеется
            if (slot.item == _item)
            {
                if (slot.amountItem + _amount <= _item.maxAmountStack)
                { 
                slot.amountItem += _amount;
                slot.textAmountText.text = slot.amountItem.ToString();
                return;
                }
            }
            break;
        }
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amountItem = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.textAmountText.text = _amount.ToString();
                break;
            }
        }
    }

   /* public void AddItemToSlot(ItemScribtableObject _item , int _amount , int slotId)
    {
        InventorySlot slots = inventorySlots[slotId];
        slots.item = _item;
        slots.isEmpty = false;
        slots.SetIcon(_item.icon);

        if (_amount <= _item.maxAmountStack)
        {
            slots.amountItem = _amount;
            if (slots.item.maxAmountStack != 1)
            {
                slots.textAmountText.text = slots.amountItem.ToString();
            }
        }
        else 
        {
            slots.amountItem = _item.maxAmountStack;
            _amount = _item.maxAmountStack;
            if (slots.item.maxAmountStack != 1)
            {
                slots.textAmountText.text = slots.amountItem.ToString();
            }
        }
    }

    public void RemoveItemeFromSlot(int slotID)
    {
        InventorySlot slot = inventorySlots[slotID];
        slot.item = null;
        slot.isEmpty = true;
        slot.amountItem = 0;
        InventorySlot.icon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        InventorySlot.icon.GetComponent<Image>().sprite = null;
        slot.textAmountText.text = "";
    }*/
}
