using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    private int health = 100;
    private bool isAttacking = false;
    private float horizontalSpeed = .05f;
    private float horizTimer = 0;

    private int id;
    private string controlPostFix;

	// Use this for initialization
	void Start () {
        id = transform.GetSiblingIndex();
        controlPostFix = string.Format("_P{0}", id+1);
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}

    void CheckInput() {
        if(GetButton("Horizontal")) {
            transform.position += Vector3.ClampMagnitude(Vector3.right * GetAxis("Horizontal"), horizontalSpeed);
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
