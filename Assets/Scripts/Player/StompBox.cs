using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject collectible;
    [Range(0, 100)] public float chanceToDrop;
    public float bounceForce = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para detectar cuando un GO ha entrado en la zona del StompBox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponentInParent<EnemyDeath>().EnemyDeathController();
            PlayerController.sharedInstance.Bounce(PlayerController.sharedInstance.bounceForce);
            float dropSelect = Random.Range(0, 100f);

            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }
        }
    }
}
