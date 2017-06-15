using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GGpanel;
    public GameObject LostPanel;

    public AudioClip MissionPassedSound;
    public AudioClip GameOverSound;
    public int enemieskiled;
    private bool isWon = true;



    void Update()
    {
        if(enemieskiled >= 10 && isWon)
        {
            GameWin();
            isWon = !isWon;
        }
    }

    public void GameWin()
    {
        GGpanel.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(MissionPassedSound);
    }
    public void GameLost()
    {
        LostPanel.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(GameOverSound);
    }

}
