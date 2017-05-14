using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public float damage = 15f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.SendMessage("HitBack", transform);
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }
}
