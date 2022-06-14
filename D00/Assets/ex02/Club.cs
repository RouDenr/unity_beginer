using UnityEngine;

public class Club : MonoBehaviour
{
    public GameObject club;
    public GameObject ball;
    private float _speed = 0f;
    private int _dir = 1;
    private int _score = -15;
    private bool _chWin = false;
    private bool _chPush = false;
    private Ball _ball;
    
    // Start is called before  sthe first frame update
    void Start()
    {
        // _ball = gameObject.
    }

    
    // Update is called once per frame
    void Update()
    {
        _ball = gameObject.AddComponent<Ball>();
        
        if (_chWin) return; 
        if (Input.GetKey(KeyCode.Space))
        {
            _speed += .0005f;
            if (_dir > 0)
                club.transform.Translate(0, -.005f, 0);
            else
                club.transform.Translate(0, .005f, 0);
            _chPush = true;
        }
        else
        {
            if (ball.GetComponent<Transform>().position.y >= 5 && _dir > 0)
                _dir = -1;
            if (ball.GetComponent<Transform>().position.y <= -5 && _dir < 0)
                _dir = 1;
            _ball.PushBall(_dir, _speed, ball);
            if (_speed > 0)
                _speed -= .0005f;
            if (_speed <= 0)
            {
                if (_chPush)
                { 
                    var poxY = ball.GetComponent<Transform>().position.y;
                    if (poxY >= 2.5 && poxY <= 3.5)
                    {
                        _chWin = true;
                        ball.GetComponent<Transform>().position = new Vector3(-15, -15, 0);
                    }
                    else if (poxY >= 3)
                    {
                        club.GetComponent<Transform>().position = new Vector3(-0.3f, poxY + 1f, 0);
                        _dir = -1;
                    }
                    else
                    {
                        club.GetComponent<Transform>().position = new Vector3(-0.3f, poxY + .2f, 0);
                        _dir = 1;
                    }
                    if (!_chWin)
                        _score += 5;
                    _chPush = false;
                    Debug.Log("Score: " + _score);
                }
                _speed = 0;
            }
        }
        // Debug.Log("speed " + _speed);
    }
}
