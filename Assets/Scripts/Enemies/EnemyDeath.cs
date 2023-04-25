using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject deathEffect;

    //Método para la muerte del enemigo
    public void EnemyDeathController()
    {
        transform.gameObject.SetActive(false);
        Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
}
