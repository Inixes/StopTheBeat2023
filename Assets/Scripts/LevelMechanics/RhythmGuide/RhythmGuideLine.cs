using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGuideLine : MonoBehaviour
{
    //public float moveSpeed;

    //private Rigidbody2D theRB;

    //public bool isInBoxRhythmGuide;

    //public static RhythmGuideLine sharedInstance;

    //private void Awake()
    //{
    //    if (sharedInstance == null)
    //    {
    //        sharedInstance = this;
    //    }
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    theRB = GetComponent<Rigidbody2D>();
    //    //GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
    //    //Destroy
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public float moveSpeed;

    public bool isInBoxRhythmGuide;

    public int counter = 0;

    public static RhythmGuideLine sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        if (counter == 2)
        {
            isInBoxRhythmGuide = true;
        }
        else
        {
            isInBoxRhythmGuide = false;
        }

        //if () jugador mecanicas
    }
}
