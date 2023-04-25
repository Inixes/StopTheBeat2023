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

    //Método para el Botón Continue
    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    //Método para el Botón Start
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    //Método para el Botón Quit
    public void QuitGame()
    {
        Application.Quit();
        //Feedback para el editor
        Debug.Log("Quitting Game");
    }
}
