using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class RhythmGuideBox : MonoBehaviour
//{
//    public GameObject guideLineIn;

//    private bool activateAction;

//    private SpriteRenderer theSR;

//    // Start is called before the first frame update
//    void Start()
//    {
//        theSR = GetComponent<SpriteRenderer>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E) && PlayerController.sharedInstance.canInteract)
//        {
//            //Si no está activado el interruptor
//            if (!activateAction)
//            {
//                //Desactivamos el objeto sobre el que actúa el interruptor
//                guideLineIn.SetActive(false);
//                //El interruptor estaría activado
//                activateAction = true;
//                PlayerController.sharedInstance.theRB.velocity = new Vector2(PlayerController.sharedInstance.moveSpeed * Input.GetAxis("Horizontal"), PlayerController.sharedInstance.theRB.velocity.y);
//            }
//            //Si por el contrario está 
//            else
//            {
//                //
//                guideLineIn.SetActive(true);
//                //
//                activateAction = false;
//            }
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        //Si es el jugador el que entra en la zona del interruptor
//        if (collision.CompareTag("LineGuide"))
//        {
//            //infoPanel.SetActive(true);
//            PlayerController.sharedInstance.canInteract = true;
//        }
//    }

//    //Método para conocer cuando un objeto sale de la zona de trigger
//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        //infoPanel.SetActive(false);
//        PlayerController.sharedInstance.canInteract = false;
//    }

//}
