using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DitzeGames.Effects;

public class DamageHandler : MonoBehaviour
{
    public ProjectileShooting ps;
    public int health;
    public bool endGameOnDeath = false;
    SpriteRenderer sp;
    public bool hasHealthBar;
    public Slider healthSlider;
    public bool hasParticleEffect;
    ParticleSystem psy;
    public bool dropsCoins;
    public GameObject coin;
    public int coinAmount;

    public Slider screenShakeAmount;


    void Start()
    {
        if (hasParticleEffect)
        {
            psy = GetComponent<ParticleSystem>();
        }      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health < 1 && endGameOnDeath == true)
        {
            //Debug.Log(health);
            SceneManager.LoadScene(0);
        }

        if (hasHealthBar)
        {
            healthSlider.value = health;
        }

        if (health < 1)
        {
            
            if (hasParticleEffect)
            {
                psy.Play();
                Destroy(gameObject, psy.main.duration);
            }
            else
            {
                Destroy(gameObject);

                for (int i = 0; i < coinAmount; i++)
                {
                    Instantiate(coin, new Vector3(transform.position.x + Random.value, transform.position.y, 0), Quaternion.identity);
                }
            }

        }

        if (endGameOnDeath)
        {
            //health++;
        }

        

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "Enemies")
        {
            ps = collision.gameObject.GetComponent<ProjectileShooting>();
            health -= ps.damage;
            ps.endAnimation = true;
            sp = GetComponent<SpriteRenderer>();
            sp.color = new Color(0, 0, 0);
        }

        if (collision.gameObject.tag == "EnemyBullet" && gameObject.tag == "Player")
        {
            ps = collision.gameObject.GetComponent<ProjectileShooting>();
            health -= ps.damage;
            ps.endAnimation = true;
            CameraEffects.ShakeOnce(amount: new Vector3(screenShakeAmount.value, screenShakeAmount.value, 0));          
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin" && gameObject.tag == "Player")
        {
            GameObject.Find("TurretManager").GetComponent<TurretManager>().Coins += 1;
            Destroy(collision.gameObject);
        }
    }
}
