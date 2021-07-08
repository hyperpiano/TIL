using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    public float speed = 3f;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float input = Input.GetAxis("Vertical");

        float playerSpeed = input * speed;

        Vector2 newVelocity = new Vector2(0, playerSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    //벽에 부딪히면 움직일 수 없다.
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.contacts[0].normal.y > 0.7f) {
            playerRigidbody.velocity = new Vector2(0, 0);
        }
        if(collision.contacts[0].normal.y < -0.7f) {
            playerRigidbody.velocity = new Vector2(0, 0);
        }
    }
}
