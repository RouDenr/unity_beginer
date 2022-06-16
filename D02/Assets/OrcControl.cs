using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcControl : MonoBehaviour
{
    public GameObject firstOrc;
    public List<GameObject> orcs;
    public GameObject spawn;

    private float _timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _timeSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _timeSpawn > 10)
        {
            GameObject newHuman = GameObject.Instantiate(firstOrc);
            orcs.Add(newHuman);
            var position = spawn.transform.position;
            newHuman.transform.position = new Vector3(position.x, position.y);
            _timeSpawn = Time.time;
        }
        
    }
}
