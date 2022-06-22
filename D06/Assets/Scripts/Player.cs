using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _player;

    private float _speed = 5f;
    private const float Speed = 5f;
    public bool isRun;
    private const float MouseSpeed = 5f;
    private Vector3 _moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _player = gameObject.GetComponent<CharacterController>();
        
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _speed = Speed * 2;
        else
            _speed = Speed;
        _moveVector = Vector3.zero;
        _moveVector = transform.forward * _speed * Input.GetAxis("Vertical");
        _moveVector += transform.right * _speed * Input.GetAxis("Horizontal");
        _player.SimpleMove(_moveVector);
        isRun = _speed > Speed && _moveVector != Vector3.zero;
    }
    
    private void MouseMove()
    {
        var x = -Input.GetAxis("Mouse Y") * MouseSpeed;
        var y = Input.GetAxis("Mouse X") * MouseSpeed;
        
        transform.Rotate(new Vector3(x, y, .0f));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        MouseMove();
    }
}
