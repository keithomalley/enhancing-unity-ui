using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public static PlayerInventory Instance = null;

    public List<Item> items;

    public int gold = 30;

    void Start() {
        Instance = this;
        Inventory.Instance.SetItems(items);
        Shop.Instance.SetShopItems();
    }

    public Item GetItem(int id) {
        foreach (Item i in items) {
            if (i.id == id) {
                return i;
            }
        }
        return null;
    }

    public bool BuyItem(int item_id) {
        bool bought = false;
        foreach(Item i in items) {
            if(i.id == item_id) {
                if(gold >= i.value) {
                    gold -= i.value;
                    i.count++;
                    bought = true;
                }
            }
        }
        return bought;
    }

}

[System.Serializable]
public class Item {
    public int id;
    public string name;
    public Sprite icon;
    public int value;
    public int count = 0;

    public Item(int i, string n, Sprite ic, int v, int c) {
        id = i;
        name = n;
        icon = ic;
        value = v;
        count = c;
    }
}