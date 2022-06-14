using UnityEngine;

public class Camera : MonoBehaviour
{
    // public GameObject camera;
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    private PlayerScript _mainPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _mainPlayer = red.GetComponent<PlayerScript>();
        _mainPlayer.isActive = true;
    }

    private void ChangePlayer(GameObject player)
    {
        _mainPlayer.isActive = false;
        _mainPlayer = player.GetComponent<PlayerScript>();
        _mainPlayer.isActive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_mainPlayer.GetX(), _mainPlayer.GetY(), -10);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangePlayer(red);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangePlayer(yellow);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangePlayer(blue);
        if (Input.GetKeyDown(KeyCode.R))
        {
            red.GetComponent<PlayerScript>().SetStartPos();
            yellow.GetComponent<PlayerScript>().SetStartPos();
            blue.GetComponent<PlayerScript>().SetStartPos();
            ChangePlayer(red);
        }
    }
}
