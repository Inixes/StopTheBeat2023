using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    public GameObject Line;
    private float timeWithinLines;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWithinLines <= 0)
        {
            timeWithinLines = startTime;
        }
        else
        {
            timeWithinLines -= Time.deltaTime;
        }
    }
}
