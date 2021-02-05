using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.EnemyKilled = 0;
        DataManager.Instance.ShotBullet = 0;
        GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "Enemy Killed: " + DataManager.Instance.EnemyKilled.ToString();
        GameObject.Find("ShotBulletText").GetComponent<Text>().text = "Shot Bullet: " + DataManager.Instance.ShotBullet.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);

    }
    public void PlayButton()
    {

        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);


    }
    public void ReplayButton()
    {

        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);

    }
    public void HomeButton()
    {

        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(1);

    }
}
