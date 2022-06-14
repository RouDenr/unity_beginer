using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private GameObject _player;
    public int score = 0;

    public Player(GameObject player)
    {
        _player = player;
    }

    public bool DoSpep(KeyCode kCodeDn, KeyCode kCodeUp)
    {
        float y = _player.GetComponent<Transform>().position.y;
        if (Input.GetKey(kCodeUp) && y < 2.5f)
        {
            _player.transform.Translate(0, .03f, 0);
            return true;
        }
        if (Input.GetKey(kCodeDn) && y > -2.5f)
        {
            _player.transform.Translate(0, -.03f, 0);
            return true;
        }
        return false;
    }
}
