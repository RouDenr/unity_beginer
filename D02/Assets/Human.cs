using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public AudioSource yesSound;
    
    private Vector2 _target;
    private const float Speed = 2.5f;

    private Animator _playerAnimation;

    private static readonly int X = Animator.StringToHash("x");
    private static readonly int Y = Animator.StringToHash("y");
    private static readonly int Speed1 = Animator.StringToHash("Speed");

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            var position = transform.position;
            _target = new Vector2(mousePos.x, mousePos.y);
            yesSound.Play();
            // Debug.Log("x:" + (position.x - mousePos.x) + " y:" + (position.y - mousePos.y));
            
            // _playerAnimation.SetFloat(Speed1, Speed);
            int x = (int) (mousePos.x - position.x );
            int y = (int) ( mousePos.y - position.y);
            _playerAnimation.SetInteger(X, x);
            _playerAnimation.SetInteger(Y, y);
        }

        transform.position = Vector2.MoveTowards(transform.position, _target
            , Time.deltaTime * Speed);
        if (transform.position.x == _target.x && transform.position.y == _target.y)
        {
            _playerAnimation.SetInteger(X, 0);
            _playerAnimation.SetInteger(Y, 0);
        }
    }
}
