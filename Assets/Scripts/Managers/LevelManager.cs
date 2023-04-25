using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public int gemCollected;
    public float timeInLevel;

    public string levelToLoad;

    public static LevelManager sharedInstance;
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
        UIController.sharedInstance.levelCompleteText.gameObject.SetActive(false);
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    //Método para respawnear al jugador cuando muere
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //Corrutina para respawnear al jugador
    public IEnumerator RespawnPlayerCo()
    {
        PlayerController.sharedInstance.gameObject.SetActive(false);
        //AudioManager.sharedInstance.PlaySFX(8);
        yield return new WaitForSeconds(waitToRespawn);
        UIController.sharedInstance.FadeToBlack();
        yield return new WaitForSeconds(waitToRespawn);
        UIController.sharedInstance.FadeFromBlack();
        PlayerController.sharedInstance.gameObject.SetActive(true);
        PlayerController.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
        PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
        UIController.sharedInstance.UpdateHealthDisplay();
    }

    //Método para terminar un nivel
    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
    }

    //Corrutina de terminar un nivel
    public IEnumerator ExitLevelCo()
    {
        PlayerController.sharedInstance.stopInput = true;
        PlayerController.sharedInstance.StopPlayer();
        //AudioManager.sharedInstance.bgm.Stop();
        //AudioManager.sharedInstance.levelEndMusic.Play();
        UIController.sharedInstance.levelCompleteText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.sharedInstance.FadeToBlack();
        yield return new WaitForSeconds(1.5f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if (gemCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
