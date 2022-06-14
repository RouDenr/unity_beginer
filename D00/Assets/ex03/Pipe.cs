using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPipe(float bY, float pX)
    {
        if (pX > 1.1f || pX < -1.1f) return false;
        if (bY < 2.4f && bY > -.7f) return false;
        return true;
    }
}
