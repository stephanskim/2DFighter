using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private SpriteRenderer health_sr;

    private int health = 25;
    private bool isAttacking = false;
    private bool isJumping = false;
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
            if (GetAxis("Horizontal") > 0)
                rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);
            else
                rigidbody2D.velocity = new Vector2(-horizontalSpeed, rigidbody2D.velocity.y);
        } else {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }

        if(GetButton("Jump") && !isJumping) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            isJumping = true;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            isJumping = false;
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
