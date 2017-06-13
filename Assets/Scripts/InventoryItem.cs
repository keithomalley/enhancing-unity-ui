using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public static GameObject currentItem = null;

    public Image icon;
    public GameObject itemCountBG;
    public Text itemCount;

    Transform originalParent;

    void Start() {
        icon = GetComponent<Image>();
        itemCountBG = GetComponentInChildren<Image>().gameObject;
        itemCount = GetComponentInChildren<Text>();
    }

    public void SetItem(Item item) {
        icon.sprite = item.icon;
        itemCount.text = item.count.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        currentItem = gameObject;
        originalParent = transform.parent;
        icon.raycastTarget = false;

        transform.SetParent(transform.parent.parent.parent);
        transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(transform.parent == originalParent.parent.parent) {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
        currentItem = null;
        icon.raycastTarget = true;
    }
}
