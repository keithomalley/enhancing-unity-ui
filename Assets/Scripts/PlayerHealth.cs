using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    float health = 100f;
    public Slider healthbar;
    public Text healthlabel;

    void Update() {
        healthbar.value = Mathf.Lerp(healthbar.value, health, Time.deltaTime * 10f);
        healthlabel.text = healthbar.value.ToString("F0");
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health < 0) health = 0;
    }

}
