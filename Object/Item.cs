using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    public string itemName;
    public Sprite sprite;
    public int quantity;
    public float amount;
    public bool stackable;
    public int[] Attack;
    public string description;
    public enum ItemType
    {
        Coin,
        RedPotion,
        BluePotion,
        Helmet,
        Armor,
        Boots,
        Weapon,
        Ring,
        Other

    }
    public ItemType itemType;
}
