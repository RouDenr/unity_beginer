using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
    
    void Start()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
