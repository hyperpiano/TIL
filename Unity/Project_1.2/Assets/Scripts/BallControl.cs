using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //공 속력 관련 변수
    public float ballSpeed = 6f;
    public float speedMin = -0.5f;
    public float speedMax = 0.5f;
    private float xSpeed;
    private float ySpeed;

    //점수 관련 변수
    public GameObject scoreObject_BallControl;
    private float blueScore;
    private float redScore;
    private float isRun;

    //공 컴포넌트 관련 변수
    public AudioClip ballSound;
    private Vector2 ballSpeedVector;
    private Rigidbody2D ballRigidbody;
    private AudioSource ballAudio;

    // Start is called before the first frame update
    void Start() {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballAudio = GetComponent<AudioSource>();
        speedSetter();
    }

    // Update is called once per frame
    void update() {
         
    }
    
    private void Score() {

        //Debug.Log("Score");

        blueScore = scoreObject_BallControl.transform.position.x;
        redScore = scoreObject_BallControl.transform.position.y;
        isRun = 1f;

        if (transform.position.x > 0) {
            redScore++;
            scoreObject_BallControl.transform.position = new Vector3(blueScore, redScore, isRun);
        }
        else {
            blueScore++;
            scoreObject_BallControl.transform.position = new Vector3(blueScore, redScore, isRun);
        }
        boardReset();
        speedSetter();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {

        //Debug.Log("OnTriggerEnter2D");

        if (other.tag == "Scorebar") {
            Score();
        }
        else if (other.tag == "Wall") {            
            ySpeed = ySpeed * -1;
            ballRigidbody.velocity = new Vector2(xSpeed, ySpeed);
            Debug.Log(ballRigidbody.velocity);
        }
        else if (other.tag == "Player") {
            if (transform.position.x < -8.4 || transform.position.x > 8.4) {
                ySpeed = ySpeed * -1;
                ballRigidbody.velocity = new Vector2(xSpeed, ySpeed);
            }
            else {
                xSpeed = xSpeed * -1;
                ballRigidbody.velocity = new Vector2(xSpeed, ySpeed);
            }
        }
    }

    private void speedSetter() {
        
        //Debug.Log("speedSetter");

        float xSpeedBase = Random.Range(-0.5f, 0.5f);
        float ySpeedBase = Random.Range(-0.5f, 0.5f);

        while (true) {
            if ((!(Mathf.Abs(xSpeedBase) > Mathf.Abs(ySpeedBase) * 3)) && (!(Mathf.Abs(xSpeedBase) * 3 < Mathf.Abs(ySpeedBase))))
                break;
            xSpeedBase = Random.Range(-0.5f, 0.5f);
            ySpeedBase = Random.Range(-0.5f, 0.5f);
        }

        float speedBase = (xSpeedBase * xSpeedBase) + (ySpeedBase * ySpeedBase);
        float multipleNum = ballSpeed / Mathf.Sqrt(speedBase);

        xSpeed = xSpeedBase * multipleNum;
        ySpeed = ySpeedBase * multipleNum;

        ballRigidbody.velocity = new Vector2(xSpeed, ySpeed);
    }
    public void boardReset() {

        //Debug.Log("boardReset");

        transform.position = Vector2.zero;
        ballRigidbody.velocity = Vector2.zero;
    }
}