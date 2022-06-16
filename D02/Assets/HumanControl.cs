using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour
{
    public GameObject firstHuman;
    public List<GameObject> humans;
    public GameObject spawn;

    private float _timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _timeSpawn = Time.time;
    }

    public void DoAllUnActive()
    {
        foreach (var human in humans)
        {
            human.GetComponent<Human>().isActive = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time - _timeSpawn > 10)
        {
            GameObject newHuman = GameObject.Instantiate(firstHuman);
            humans.Add(newHuman);
            var position = spawn.transform.position;
            newHuman.transform.position = new Vector3(position.x, position.y);
            _timeSpawn = Time.time;
        }
    }
}
