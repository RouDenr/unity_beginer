using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringScript : MonoBehaviour
{
    // Start is called before the first frame

    private void OnTriggerEnter2D(Collider2D col)
    {
        int score = PlayerPrefs.GetInt ("numberOfRings");
        PlayerPrefs.SetInt("numberOfRings", ++score);
        Debug.Log("kek");
        Destroy(gameObject);
    }
    // private void OnCollisionEnter2D(Collision collision)
    // {
    //     // int score = PlayerPrefs.GetInt ("numberOfRings");
    //     // PlayerPrefs.SetInt("numberOfRings", ++score);
    //     Debug.Log("kek");
    //     // gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    // }
}
