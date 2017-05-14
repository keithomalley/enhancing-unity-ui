using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    float moveWeight = 20f;
    bool canMove = true;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (canMove) {
            if(rb.velocity.magnitude > 3f) {
                Debug.Log("Stop!");
            } else {
                Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }

    void Move(float x, float z) {
        Debug.Log(x + ", " + z);
        rb.AddForce(new Vector3(x * moveWeight, 0f, z * moveWeight));
    }

    void HitBack(Transform hit) {
        canMove = false;
        rb.velocity = new Vector3(0f,0f,0f);
        rb.AddForce((transform.position - hit.position) * 500);
        Invoke("LetMove", 1f);
    }

    void LetMove() {
        canMove = true;
    }


}
