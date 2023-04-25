using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Checkpoint[] checkpoints;
    public Vector3 spawnPoint;

    public static CheckpointController sharedInstance;
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
        checkpoints = GetComponentsInChildren<Checkpoint>();
        spawnPoint = PlayerController.sharedInstance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para desactivar los checkpoints
    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    //Método para generar el punto de reaparición del jugador
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
