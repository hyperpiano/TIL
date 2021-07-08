using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Rigidbody2D AIRigidbody;
    private GameObject Ball;
    private Rigidbody2D BallRigidbody;

    public float speed = 5f;

    void Start() {
        AIRigidbody = GetComponent<Rigidbody2D>();
        Ball = GameObject.Find("Ball");
        BallRigidbody = Ball.GetComponent<Rigidbody2D>();
    }

    void Update() {
        float input = 0;

        if (Ball.transform.position.y >= transform.position.y) {
            input = 1;
        }
        else if (Ball.transform.position.y <= transform.position.y) {
            input = -1;
        }

        float playerSpeed = input * speed;

        Vector2 newVelocity = new Vector2(0, playerSpeed);

        AIRigidbody.velocity = newVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.contacts[0].normal.y > 0.7f) {
            AIRigidbody.velocity = new Vector2(0, 0);
        }
        if (collision.contacts[0].normal.y < -0.7f) {
            AIRigidbody.velocity = new Vector2(0, 0);
        }
    }
}
