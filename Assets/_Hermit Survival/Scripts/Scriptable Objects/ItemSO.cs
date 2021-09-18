using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hermit/Item")]

public class ItemSO : ScriptableObject {

    public enum ItemType {
        Wood,
        Fiber,
        Stone,
        Iron,
        Hide,
        Health,
        Food,
        Water,
        Poison //negative value
    }

    public ItemType itemType;
    public string itemName;

    [Tooltip("If health and related number is 100, it will restore 100 health")]
    public float relatedNumber;
    public bool isStackable;
    public int maxStackSize;
    public float weight;
    public float health;
}