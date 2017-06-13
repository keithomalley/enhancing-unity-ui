using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public static Shop Instance = null;

    public GameObject shopWindow;
    public int[] itemIds;
    public ShopButton[] shopButtons;

    void Awake() {
        Instance = this;
        HideShop();
    }

    public void SetShopItems() {
        foreach(int i in itemIds) {
            // instantiate a button in the shop
            Item item = PlayerInventory.Instance.GetItem(i);
            if(item != null) {
                // Set the button values
                shopButtons[i].SetItem(item);
            }
        }
    }


    public void ShowShop() {
        shopWindow.SetActive(true);
    }

    public void HideShop() {
        shopWindow.SetActive(false);
    }
}
