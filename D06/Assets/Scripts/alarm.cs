using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class alarm : MonoBehaviour
{
    private Slider _slider;
    private const float SliderSpeed = 20f;
    
    public bool playerUnderCamera;
    public Player player;
    public AudioSource soundAlarm;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isRun || playerUnderCamera)
        {
            if (_slider.value > 50 && !soundAlarm.isPlaying)
                soundAlarm.Play();   
            if (playerUnderCamera)
                _slider.value += SliderSpeed * Time.deltaTime * 3f;
            else
                _slider.value += SliderSpeed * Time.deltaTime;
                
        }
        else
        {
            soundAlarm.Stop();
            _slider.value -= SliderSpeed * Time.deltaTime; 
        }
        
        if (_slider.value >= 100)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
