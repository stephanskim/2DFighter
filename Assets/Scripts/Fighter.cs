using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    private int health = 100;
    private bool isAttacking = false;
    private float horizontalSpeed = .05f;
    private float horizTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkInput();
	}

    void checkInput() {
        if(Input.GetKey(KeyCode.A)) {
            if (horizTimer < horizontalSpeed) {
                horizTimer += Time.deltaTime;
                return;
            }
            horizTimer = 0;
            transform.position += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            if (horizTimer < horizontalSpeed) {
                horizTimer += Time.deltaTime;
                return;
            }
            horizTimer = 0;
            transform.position += Vector3.right;
        }
    }



}
