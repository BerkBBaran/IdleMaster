using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    private int leftBullet;

    public EasyFileSave myFile;
   

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);
        myFile.Save();
    }
    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public int EnemyKilled
    {
        get
            {
            return enemyKilled;
            }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "Enemy Killed: " + enemyKilled.ToString();
            WinProcess();
        }
    }


    public int ShotBullet {

        get
        {
            return shotBullet;
        }

        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "Shot Bullet: " + shotBullet.ToString();
        }
    }
    public int LeftBullet
    {

        get
        {
            return leftBullet;
        }

        set
        {
            leftBullet = value;
            GameObject.Find("LeftBulletText").GetComponent<Text>().text = leftBullet.ToString();
        }
    }
    public void WinProcess()
    {
        if(enemyKilled >= 4)
        {

        }

    }
    public void LoseProcess()
    {

    }
}
