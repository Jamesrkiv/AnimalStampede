using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Item")]

public class Item : ScriptableObject
{
    //Container to hold data on the banana
    public GameObject banana;

    public int quantity; 

    public bool stackable;

    public enum ItemType
    {
        BANANA
    }

    public ItemType itemType;
}
