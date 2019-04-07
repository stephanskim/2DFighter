using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    [SerializeField] private float horizontalSpeed = .05f;

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private SpriteRenderer health_sr;

    private int health = 25;
    private bool isAttacking = false;
    private int id;
    private string controlPostFix;
    private float maxHealthSRWidth;

	// Use this for initialization
	void Start () {
        id = transform.GetSiblingIndex();
        controlPostFix = string.Format("_P{0}", id+1);
        name = string.Format("Fighter_{0}", id+1);

        if (rigidbody2D.Equals(null))
            rigidbody2D = GetComponent<Rigidbody2D>();

        if (health_sr.Equals(null))
            health_sr = transform.Find("Green").GetComponent<SpriteRenderer>();

        maxHealthSRWidth = health_sr.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        CheckHealth();
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

    void CheckHealth() {
        health_sr.size = new Vector2(maxHealthSRWidth / 100 * health, health_sr.size.y);
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
