using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    [SerializeField] private float horizontalSpeed = .05f;

    private int health = 100;
    private bool isAttacking = false;
    private Rigidbody2D rigidbody2D;
    private int id;
    private string controlPostFix;


	// Use this for initialization
	void Start () {
        id = transform.GetSiblingIndex();
        controlPostFix = string.Format("_P{0}", id+1);
        name = string.Format("Fighter_{0}", id+1);

        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}

    void CheckInput() {
        if(GetButton("Horizontal")) {
            rigidbody2D.MovePosition(rigidbody2D.position + Vector2.ClampMagnitude(Vector3.right * GetAxis("Horizontal"), horizontalSpeed));
        }

        if(GetButton("Fire1")) {
            isAttacking = true;
        } else {
            isAttacking = false;
        }
    }

    private float GetAxis(string axisName) {
        return Input.GetAxis(GetControlString(axisName));
    }

    private bool GetButton(string buttonName) {
        return Input.GetButton(GetControlString(buttonName));
    }

    private string GetControlString(String controlName) {
        return controlName + controlPostFix;
    }

}
