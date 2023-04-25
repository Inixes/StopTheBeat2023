using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene, continueScene;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para el Bot�n Continue
    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    //M�todo para el Bot�n Start
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    //M�todo para el Bot�n Quit
    public void QuitGame()
    {
        Application.Quit();
        //Feedback para el editor
        Debug.Log("Quitting Game");
    }
}
