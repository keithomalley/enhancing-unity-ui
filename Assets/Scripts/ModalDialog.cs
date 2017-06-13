using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalDialog : MonoBehaviour {
    public static ModalDialog Instance = null;

    public Text dialogText;
    public Button confirmBtn;
    public Text confirmText;
    public Text cancelText;

    public GameObject overlay;
    public GameObject dialogWindow;

    void Start() {
        Instance = this;
        HideDialog();
    }

    public void SetDialog(DialogObject d) {
        ShowDialog();
        dialogText.text = d.dText;
        confirmText.text = d.confirmText;
        cancelText.text = d.cancelText;

        confirmBtn.onClick.RemoveAllListeners();
        confirmBtn.onClick.AddListener(d.confirmEvent.Invoke);
    }

    public void ShowDialog() {
        overlay.SetActive(true);
        dialogWindow.SetActive(true);
    }

    public void HideDialog() {
        overlay.SetActive(false);
        dialogWindow.SetActive(false);
    }

}

[System.Serializable]
public class DialogObject {
    public string dText;
    public string confirmText;
    public string cancelText;
    public UnityEvent confirmEvent;
}