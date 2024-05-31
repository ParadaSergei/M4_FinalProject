using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Lovushka, LightPalka, KeyCard}
public class ItemScribtableObject : ScriptableObject
{
    public ItemType ItemType;
    public string name;
    public int maxAmountStack;
    public Sprite icon;
    public GameObject lovushkaPrefab;

    [Header("Treatment")]
    public float changedHealth;
}
