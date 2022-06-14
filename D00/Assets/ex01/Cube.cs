using UnityEngine;

public class Cube
{
    private readonly GameObject _cube;
    private float _speed;
    
    // Start is called before the first frame update
    // private void Start()
    // {
    //     _cloneCube = Instantiate(cube);
    //     _speed = Random.Range(-.015f, -.001f);
    // }

    public Cube(GameObject cube)
    {
        _cube = GameObject.Instantiate(cube);
        _cube.transform.Translate(0, Random.Range(0, 10), 0);
        _speed = Random.Range(-.015f, -.005f);
    }

    private float GetAccuracy(float y)
    {
        if (y < 0) y *= -1;
        return 100 - y * 25;
    }
    
    public bool CheckToDestroy(KeyCode kCode)
    {
        if (!Input.GetKeyDown(kCode)) return false;
        if (!(_cube.GetComponent<Transform>().position.y <= 4)) return false;
        GameObject.Destroy(_cube);
        Debug.Log("Precision: " + GetAccuracy(_cube.GetComponent<Transform>().position.y));
        return true;
    }

    public void DoStep()
    {
        _cube.transform.Translate(0, _speed, 0);
        if (_cube.GetComponent<Transform>().position.y < -4)
        {
            _speed = Random.Range(-.015f, -.005f);
            _cube.transform.Translate(0, Random.Range(10, 20), 0);
        }
    }
    
}
