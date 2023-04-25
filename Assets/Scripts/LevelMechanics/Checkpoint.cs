using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para conocer cuando el jugador entra en la zona de checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && theSR.sprite == cpOff)
        {
            CheckpointController.sharedInstance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
            //AudioManager.sharedInstance.PlaySFX(11);
            CheckpointController.sharedInstance.SetSpawnPoint(transform.position);
        }
    }

    //Método para desactivar los Checkpoints
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
