using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour {

    bool on = false;
    Animator anim;
    public UnityEvent onSwitchOn;
    public UnityEvent onSwitchOff;

    void Start() {
        anim = GetComponent<Animator>();
    }
    
    void OnTriggerEnter(Collider other) {
        on = true;
        anim.SetBool("On", on);
        onSwitchOn.Invoke();
    }


    void OnTriggerExit(Collider other) {
        on = false;
        anim.SetBool("On", on);
        onSwitchOff.Invoke();
    }

}
