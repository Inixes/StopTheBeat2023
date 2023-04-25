using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    //Método para detectar cuando un objeto entra en la zona de salida del nivel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.sharedInstance.ExitLevel();
        }
    }
}
