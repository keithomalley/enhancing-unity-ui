using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

    public Button btn;
    public Text itemName;
    public Text itemValue;
    public Image itemIcon;


    public void SetItem(Item i) {
        itemName.text = i.name;
        itemValue.text = i.value + " gold";
        itemIcon.sprite = i.icon;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate() {
            PlayerInventory.Instance.BuyItem(i.id);
        });
    }
	
}
