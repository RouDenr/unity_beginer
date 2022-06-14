using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    public GameObject pipe;
    private float _speed = -.003f;
    private float _time;
    private int _score;
    private bool _chLose = false;
    private bool _blockSc = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_chLose) return;
        Debug.Log("Score: " + _score);
        Debug.Log("Time: " + Mathf.RoundToInt(Time.time - _time) + "s");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bird.transform.Translate(0, 1f, 0);
        }
        else
        {
            bird.transform.Translate(0, -.004f, 0);
        }
        pipe.transform.Translate(_speed, 0, 0);
        float pipeX = pipe.GetComponent<Transform>().position.x;
        if (pipeX < .5f && pipeX > -.5f && !_blockSc)
        {
            _score += 5;   
            _speed -= .005f;
            _blockSc = true;
        }

        if (pipeX < -4)
        {
            _blockSc = false;   
            pipe.transform.Translate(9, 0, 0);
        }
        float birdY = bird.GetComponent<Transform>().position.y;
        if (birdY <= -3.5)
            _chLose = true;
        if (Pipe.isPipe(birdY, pipeX))
            _chLose = true;
    }
}
