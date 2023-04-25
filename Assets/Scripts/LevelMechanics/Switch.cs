using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;
    public Sprite downSprite, upSprite;
    private bool activateSwitch;
    public GameObject infoPanel;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerController.sharedInstance.canInteract)
        {
            if (!activateSwitch)
            {
                objectToSwitch.SetActive(false);
                activateSwitch = true;
                theSR.sprite = downSprite;
            }
            else
            {
                objectToSwitch.SetActive(true);
                activateSwitch = false;
                theSR.sprite = upSprite;
            }
        }
    }

    //Método para conocer cuando un objeto entra en la zona de Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            PlayerController.sharedInstance.canInteract = true;
        }
    }

    //Método para conocer cuando un objeto sale de la zona de Trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        infoPanel.SetActive(false);
        PlayerController.sharedInstance.canInteract = false;
    }
}
