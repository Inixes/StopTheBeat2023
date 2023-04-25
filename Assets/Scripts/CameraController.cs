using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    //public Transform farBackground, middleBackground;
    private float minHeight, maxHeight;

    private float lastXPos;
    private float lastYPos;

    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        float amountToMoveX = transform.position.x - lastXPos;

        //farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
        //middleBackground.position += new Vector3(amountToMoveX * .5f, 0f, 0f);

        lastXPos = transform.position.x;
    }
}
