using UnityEngine;

public class PlayerScript01 : MonoBehaviour
{
    private Rigidbody2D _player;
    public bool isActive;
    
    public float pJump;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool _isTouchingGround
        ;
    public Transform centerCheck;
    public float centerCheckRadius;
    public LayerMask centerLayer;

    public float pSpeed;

    private float _startX;
    private float _startY;
    
    // Start is called before the first frame update
    void Start()
    { 
        _player = GetComponent<Rigidbody2D>();
        var position = _player.transform.position;
        _startX = position.x;
        _startY = position.y;
    }

    public void SetStartPos()
    {
        _player.GetComponent<Transform>().position = new Vector3(_startX, _startY);
    }
    
    public void SetActive()
    {
        SetLayer("Player");
        isActive = true;
        _player.mass = 1;
    }
    
    public void SetFreeze()
    {
        SetLayer("Ground");
        isActive = false;
        _player.mass = 500;
    }

    private void SetLayer(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
    }

    public bool CheckWin()
    {
        return Physics2D.OverlapCircle(centerCheck.position, centerCheckRadius, centerLayer);
    }
    
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("x:" + groundLayer + " " + gameObject.GetComponent<LayerMask>().value);
        if (!isActive) return;
        var position = groundCheck.position;
        _isTouchingGround = Physics2D.OverlapCircle(position,
                                groundCheckRadius, groundLayer);
        DoSpep(KeyCode.RightArrow ,KeyCode.LeftArrow);
        DoJump();
        CheckWin();
    }

    private void DoSpep(KeyCode kCodeRight, KeyCode kCodeLeft)
    {
        if (Input.GetKey(kCodeRight))
        {
            // player.transform.Translate(.003f, 0, 0);
            _player.velocity = new Vector2(pSpeed, _player.velocity.y);
            return ;
        }
        if (Input.GetKey(kCodeLeft))
        {
            _player.velocity = new Vector2(-pSpeed, _player.velocity.y);
            // player.transform.Translate(-.003f, 0, 0);
        }
    }
    private void DoJump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (!_isTouchingGround) return;
        _player.velocity = new Vector2(0, pJump);
    }
    
    // public void SetFreeze()
    // {
    //     _player.constraints = RigidbodyConstraints2D.FreezePositionX;
    // }
    //
    // public bool SetUnfreeze()
    // {
    //     return (_player.constraints & ~RigidbodyConstraints2D.FreezePositionX) != 0;
    // }
    public float GetX()
    {
        return _player.transform.position.x;
    }
    
    public float GetY()
    {
        return _player.transform.position.y;
    }
    
}
