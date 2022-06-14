using UnityEngine;

public class Balloon : MonoBehaviour
{
	public GameObject ball;
	private bool _stop;
	private int _stamina = 40;
	public float ballX;
	public float ballY;
	private float _startTime;

    // Start is called before the first frame update
    private void Start()
    {
	    _startTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
	    if (_stop) return;
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    if (ballX < 8)
		    {
			    if (_stamina-- > 0)
			    {
				    ballX += 0.3f;
					ballY += 0.3f;
			    }
		    }
		    else
		    {
			    var endTime = Mathf.RoundToInt(Time.time - _startTime);
			    Debug.Log("Balloon life time: " + endTime + "s");
			    Destroy(ball);
			    _stop = true;
		    }
	    }
	    else if (ballX > 0.1f)
	    {
		    ballX -= 0.001f;
		    ballY -= 0.001f;
	    }
	    else
	    {
		    var endTime = Mathf.RoundToInt(Time.time - _startTime);
		    Debug.Log("Balloon life time: " + endTime + "s");
			Destroy(ball);
		    _stop = true;
	    }
	    ball.GetComponent<Transform>().localScale = new Vector3(ballX, ballY, 0.1f);
    }
}
