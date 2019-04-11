using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float maxAttackTime = 1f;

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private SpriteRenderer health_sr;
    [SerializeField] private Animator animator;

    private int id;

    private int health = 25;
    private float attackTimer = 0f;
    private float maxHealthSRWidth;
    private bool isAttacking = false;
    private bool isJumping = false;

    private string controlPostFix;

    public bool IsAttacking {
        get {
            return isAttacking;
        }
    }

    // Initilization
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

    // Updates once every 1s/60
    void FixedUpdate() {
        
    }

    // Check Input for each control on this fighter
    void CheckInput() {
        if(GetButton("Horizontal")) {
            if (GetAxis("Horizontal") > 0) {
                rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else {
                rigidbody2D.velocity = new Vector2(-horizontalSpeed, rigidbody2D.velocity.y);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("move", true);
        } else {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

            animator.SetBool("move", false);
        }

        if(GetButton("Jump") && !isJumping) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            isJumping = true;
        }

        if (GetButton("Fire1") && attackTimer == 0) {
            attackTimer = 1f;
            isAttacking = true;
        }
    }

    // Check Health and update health bar
    void CheckHealth() {
        if (health <= 0) {
            gameObject.SetActive(false);
        }

        health_sr.size = new Vector2(maxHealthSRWidth / 100 * health, health_sr.size.y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Fighter") &&
            collision.gameObject.GetComponent<Fighter>().IsAttacking) {
            health -= 5;
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
