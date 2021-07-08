using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject score;
    public GameObject ball;
    public GameObject AIPlayer;
    public GameObject UserPlayer;
    public Text scoreText;
    public Text winTexttext;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float blueScore = score.transform.position.x;
        float redScore = score.transform.position.y;
        float isRun = score.transform.position.z;

        if (isRun == 1) {
            scoreText.text = redScore + " : " + blueScore;

            if ((blueScore == 11) || (redScore == 11)) {
                if (blueScore == 11) {
                    winTexttext.text = "Blue Wins!";
                }
                else {
                    winTexttext.text = "Red Wins!";
                }
                winText.SetActive(true);
                ball.SetActive(false);
                AIPlayer.SetActive(false);
                UserPlayer.SetActive(false);
            }
        }
    }
}
