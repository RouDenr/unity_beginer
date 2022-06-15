using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    // public GameObject camera;
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    private PlayerScript01 _mainPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _mainPlayer = red.GetComponent<PlayerScript01>();
    }

    private void ChangePlayer(GameObject player)
    {
        _mainPlayer.SetFreeze();
        _mainPlayer = player.GetComponent<PlayerScript01>();
        _mainPlayer.SetActive();
    }

    private bool CheckWin()
    {
        if (!red.GetComponent<PlayerScript01>().CheckWin()) return false;
        return yellow.GetComponent<PlayerScript01>().CheckWin() && blue.GetComponent<PlayerScript01>().CheckWin();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (CheckWin())
            Debug.Log("You Win");
    }
}
