using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para saber cuando el jugador ha entrado en la zona de muerte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthController.sharedInstance.currentHealth = 0;
            UIController.sharedInstance.UpdateHealthDisplay();
            LevelManager.sharedInstance.RespawnPlayer();
        }
    }
}
