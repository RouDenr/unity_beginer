
using UnityEngine;

public class Human : MonoBehaviour
{
    public AudioSource yesSound;
    public GameObject cameraControl;
    private HumanControl _mainControl;
    
    
    private Vector2 _target;
    private const float Speed = 2.5f;

    public bool isActive;

    private Animator _playerAnimation;

    private static readonly int X = Animator.StringToHash("x");
    private static readonly int Y = Animator.StringToHash("y");

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        _mainControl = cameraControl.GetComponent<HumanControl>();
        _target = transform.position;
        _playerAnimation = GetComponent<Animator>();
    }

    //
    // private void OnMouseUpAsButton()
    // {
    //     Debug.Log("yes");
    // }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isActive = true;
        }
        else if (isActive)
            isActive = false;
        else
        {
            _mainControl.DoAllUnActive();
            isActive = true;
        }
        // !_isActive;
        // throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        if (Camera.main != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            transform.position = Vector2.MoveTowards(position, _target
                , Time.deltaTime * Speed);
            if (transform.position.x == _target.x && transform.position.y == _target.y)
            {
                _playerAnimation.SetInteger(X, 0);
                _playerAnimation.SetInteger(Y, 0);
            }
        
            
        
            if(!isActive) return;
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                _target = new Vector2(mousePos.x, mousePos.y);
                yesSound.Play();
                // Debug.Log("x:" + (position.x - mousePos.x) + " y:" + (position.y - mousePos.y));
                
                // _playerAnimation.SetFloat(Speed1, Speed);
                int x = (int) (mousePos.x - position.x );
                int y = (int) ( mousePos.y - position.y);
                _playerAnimation.SetInteger(X, x);
                _playerAnimation.SetInteger(Y, y);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            isActive = false;
        }

    }
}
