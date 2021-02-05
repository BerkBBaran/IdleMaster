using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed, bulletAmount,LeftBullet;
    bool dead = false;
    Transform muzzle;
    public Transform bullet,floatingText,bloodParticle;
    public Slider slider;
    bool mouseon;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
        DataManager.Instance.LeftBullet = Convert.ToInt32(bulletAmount);
        LeftBullet = DataManager.Instance.LeftBullet;
    }

    // Update is called once per frame
    void Update()
    {
        mouseon = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && LeftBullet>0 && mouseon)
        {
            ShootBullet();
        }
    }
    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        
        if((health-damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
           
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 2f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
            
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.LeftBullet--;
        DataManager.Instance.ShotBullet++;
        LeftBullet--;
        

    }
}
