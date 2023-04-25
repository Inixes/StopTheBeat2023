using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;
    public string levelToLoad, levelToCheck;
    public string levelName;

    public int gemCollected, totalGems;
    public float bestTime, targetTime;

    public GameObject gemBadge, timeBadge;

    // Start is called before the first frame update
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToCheck + "_gems"))
            {
                gemCollected = PlayerPrefs.GetInt(levelToCheck + "_gems");
            }

            if (PlayerPrefs.HasKey(levelToCheck + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToCheck + "_time");
                Debug.Log(PlayerPrefs.GetFloat(levelToCheck + "_time"));
            }

            if (gemCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }

            if (bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }

            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }

            if (levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
