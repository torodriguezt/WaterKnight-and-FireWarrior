using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int points=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void increasePoints()
    {
        this.points++;
        Debug.Log(points);
    }
}
