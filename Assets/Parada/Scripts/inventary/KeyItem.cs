using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Name", menuName = "Inventory/Item/KeyItem")]
public class KeyItem : ItemScribtableObject
{
   // public GameObject prefab;
    private void Start()
    {
        ItemType = ItemType.Lovushka;
    }
}
