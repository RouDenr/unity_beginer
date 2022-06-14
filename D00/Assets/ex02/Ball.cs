
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ball.GetComponent<Transform>().position = new Vector3(0, -3f, 0);
    }
    public void PushBall(int dir, float ballSpeed, GameObject ball)
    {
        if (dir > 0)
            ball.transform.Translate(0, ballSpeed, 0);
        else
            ball.transform.Translate(0, -ballSpeed, 0);
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
