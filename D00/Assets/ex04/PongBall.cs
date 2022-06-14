using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject objLPlayer;
    public GameObject objRPlayer;
    private Player _lPlayer;
    private Player _rPlayer;
    private float xDirBall;
    private float yDirBall;
    // Start is called before the first frame update
    void Start()
    {
        _rPlayer = new Player(objRPlayer);
        _lPlayer = new Player(objLPlayer);
        startBall();
    }

    private void startBall()
    {
        ball.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        xDirBall = Random.Range(.01f, .02f);
        yDirBall = Random.Range(-.02f, -.01f);
    }

    private void stepBall()
    {
        float ballY = ball.GetComponent<Transform>().position.y;
        float ballX = ball.GetComponent<Transform>().position.x;
        float rY = objRPlayer.GetComponent<Transform>().position.y;
        float lY = objLPlayer.GetComponent<Transform>().position.y;
        
        if (ballY >= 4 || ballY <= -4)
            yDirBall = -yDirBall;
        if (ballX > 10)
        {
            startBall();
            _lPlayer.score++;
            Debug.Log("Player 1: " + _lPlayer.score + " | Player 2: " + _rPlayer.score);
        }
        if (ballX < -10)
        {
            startBall();
            _rPlayer.score++;
            Debug.Log("Player 1: " + _lPlayer.score + " | Player 2: " + _rPlayer.score);
        }

        if (ballX >= 8.8f && ballX < 10)
        {
            if (ballY <= rY + 1.2f && ballY >= rY - 1.2f)
                xDirBall = -xDirBall;
        }
        if (ballX <= -9f && ballX > -10)
        {
            if (ballY <= lY + 1.2f && ballY >= lY - 1.2f) 
                xDirBall = -xDirBall;
        }
        ball.transform.Translate(xDirBall, yDirBall, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        _lPlayer.DoSpep(KeyCode.S, KeyCode.W);
        _rPlayer.DoSpep(KeyCode.DownArrow, KeyCode.UpArrow);
        stepBall();
        
    }
}
