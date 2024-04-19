using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Name", menuName = "Inventory/Item/KeyItem")]
public class ItemWhoTypes : ItemScribtableObject
{
    private void Start()
    {
        ItemType = ItemType.Lovushka;
    }
}
