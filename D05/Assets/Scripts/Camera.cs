using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody _ballRigidbody;
    private Rigidbody _cameraRigidbody;
    private bool _isPush;
    private bool _isReadyPush;
    private const float Speed = 25f;
    private float _camSens = 5f;
    private float _rotX;
    private float _rotY;
    // private Vector3 _lastMouse = new Vector3(255, 255, 255);
    // Start is called before the first frame update
    void Start()
    {
        _ballRigidbody = ball.GetComponent<Rigidbody>();
        _cameraRigidbody = gameObject.GetComponent<Rigidbody>();
        SetCameraOnBall();
    }

    private void SetCameraOnBall()
    {
        var position = ball.transform.position;
        var rotation = ball.transform.rotation;
        var transform1 = transform;
        transform1.position = new Vector3(position.x, position.y + 1, position.z - 2f);
        // transform1.position = new Vector3(0, 0, 0);
        _rotX = 0;
        _rotY = 0;
        transform1.rotation = new Quaternion(rotation.x, rotation.y , rotation.z , rotation.w);
        _isReadyPush = true;
    }

    void MoveCamera(float x, float y, float z)
    {
        _isReadyPush = false;
        _cameraRigidbody.constraints = ~RigidbodyConstraints.FreezeAll;
        // _cameraRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
        var velocity = new Vector3(x, y, z);
        _cameraRigidbody.velocity = velocity;
    }
    
    private void KeyHook()
    {
        var velocity = _cameraRigidbody.velocity;
        
        if (Input.GetKeyDown(KeyCode.Space) && _ballRigidbody.velocity.magnitude == 0)
        {
            if (_isReadyPush)
            {
                ball.GetComponent<Ball>().PushBall();
                _isPush = true;
            }
            else
                SetCameraOnBall();
        }
        if (Input.GetKey(KeyCode.E))
            MoveCamera(velocity.x, Speed, velocity.z);
        else if (Input.GetKey(KeyCode.Q))
            MoveCamera(velocity.x, -Speed, velocity.z);
        else if (Input.GetKey(KeyCode.W))
            MoveCamera(velocity.x, velocity.y, Speed);
        else if (Input.GetKey(KeyCode.A))
        {
            if (_isReadyPush)
                RotateCamera(1f);
            else
                MoveCamera(-Speed, velocity.y, velocity.z);
        }
        else if (Input.GetKey(KeyCode.S))
            MoveCamera(velocity.x, velocity.y, -Speed);
        else if (Input.GetKey(KeyCode.D))
        {
            if (_isReadyPush)
                RotateCamera(-1f);
            else
                MoveCamera(Speed, velocity.y, velocity.z);
        }
        else
            _cameraRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            
    }

    private void RotateCamera(float x)
    {
        ball.GetComponent<Ball>().ChangeRotationX(x);
        SetCameraOnBall();
    }

    // Update is called once per frame
    void Update()
    {
        KeyHook();
        if (!_isReadyPush)
            MouseHook();
        if (Mathf.Abs(ball.GetComponent<Rigidbody>().velocity.magnitude) == 0 && _isPush)
        {
            _isPush = false;
            SetCameraOnBall();
        }
    }

    
    private void MouseHook()
    {

        _rotY += Input.GetAxis("Mouse X") * _camSens ;
        _rotX += Input.GetAxis("Mouse Y") * _camSens ;
        
        transform.rotation = Quaternion.Euler(-_rotX, _rotY, 0);


        // _cameraRigidbody.constraints |= ~RigidbodyConstraints.FreezeRotation;
        // _cameraRigidbody.rotation = Quaternion.Euler(-_rotX, _rotY, 0);
        // _cameraRigidbody.
        // _cameraRigidbody.constraints |= RigidbodyConstraints.FreezeRotation;
    }
}
    // _lastMouse = Input.mousePosition - _lastMouse ;
    // _lastMouse = new Vector3(-_lastMouse.y * _camSens, _lastMouse.x * _camSens, 0 );
    // var transform1 = transform;
    // var eulerAngles = transform1.eulerAngles;
    // _lastMouse = new Vector3(eulerAngles.x + _lastMouse.x , eulerAngles.y + _lastMouse.y, 0);
    // eulerAngles = _lastMouse;
    // transform1.eulerAngles = eulerAngles;
    // _lastMouse =  Input.mousePosition;
