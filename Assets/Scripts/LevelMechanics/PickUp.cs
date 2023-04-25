using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isGem, isHeal;
    private bool isCollected;
    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para interactuar con los objetos al entrar en su zona
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.sharedInstance.gemCollected++;
                isCollected = true;
                UIController.sharedInstance.UpdateGemCount();
                //AudioManager.sharedInstance.PlaySFX(6);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (isHeal)
        {
            if (PlayerHealthController.sharedInstance.currentHealth != PlayerHealthController.sharedInstance.maxHealth)
            {
                PlayerHealthController.sharedInstance.HealPlayer();
                isCollected = true;
                //AudioManager.sharedInstance.PlaySFX(7);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }
}
