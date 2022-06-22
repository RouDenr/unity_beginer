using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _rotX;
    private bool _isFreeze;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rotX = 0;
        _isFreeze = false;
    }

    public void PushBall()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.velocity = transform.forward * 30f;
        // _rigidbody.velocity = 
    }
    
    public void ChangeRotationX(float speed)
    {
        _rotX += speed;
        _rigidbody.rotation = Quaternion.Euler(0, -_rotX, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.magnitude) < 1.3f)
        {
        
            if (!_isFreeze)
            {
                // _rigidbody.rotation = new Quaternion(0, 0, 0, 0);
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                _isFreeze = true;
                _rigidbody.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
        else
            _isFreeze = false;

    }
}
