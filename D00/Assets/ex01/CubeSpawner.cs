using UnityEngine;

// using Cube

public class CubeSpawner : MonoBehaviour
{
    public GameObject a;
    public GameObject s;
    public GameObject d;
    private Cube _cubeA;
    private Cube _cubeS;
    private Cube _cubeD;
    // Start is called before the first frame update
    void Start()
    {
        _cubeA = new Cube(a);
        _cubeS = new Cube(s);
        _cubeD = new Cube(d);
        // _cubeA = a.GetComponent<Cube>();
        // _cubeA.SetSpeed(Random.Range(-.015f, -.001f));
    }

    // private void CubeDo(GameObject cubeObj, Cube cube, KeyCode keyCub)
    // {
    //     if (cube.CheckToDestroy(keyCub))
    //         _cubeA = new Cube(a);
    //     cube.DoStep();
    // }
    
    // Update is called once per frame
    void Update()
    {
        if (_cubeA.CheckToDestroy(KeyCode.A))
            _cubeA = new Cube(a);
        _cubeA.DoStep();
        if (_cubeS.CheckToDestroy(KeyCode.S))
            _cubeS = new Cube(s);
        _cubeS.DoStep();
        if (_cubeD.CheckToDestroy(KeyCode.D))
            _cubeD = new Cube(d);
        _cubeD.DoStep();
    }
}
