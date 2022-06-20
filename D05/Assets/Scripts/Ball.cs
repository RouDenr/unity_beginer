using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _rotX;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rotX = transform.rotation.x;
    }

    public void PushBall()
    {
        _rigidbody.constraints = ~RigidbodyConstraints.FreezeAll;
        _rigidbody.velocity = new Vector3(0, 5f, 5f);
    }
    
    public void ChangeRotationX(float speed)
    {
        _rotX += speed;
        transform.rotation = Quaternion.Euler(0,_rotX, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.magnitude) < 1.3f)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY 
                                                                         | RigidbodyConstraints.FreezeRotationX;
            transform.rotation = new Quaternion(0, 0, _rotX, 0);
        }
    }
}
