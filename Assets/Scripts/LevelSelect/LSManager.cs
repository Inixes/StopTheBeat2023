using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer;
    private MapPoint[] allPoints;

    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método que carga el nivel
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    //Corrutina para cargar un nivel
    public IEnumerator LoadLevelCo()
    {
        LSUIcontroller.sharedInstance.FadeToBlack();
        //AudioManager.sharedInstance.PlaySFX(4);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
