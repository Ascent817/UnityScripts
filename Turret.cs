using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Camera cam;
    Vector2 mousePos;
    Vector2 lookdir;
    public GameObject bulletPrefab;
    ProjectileShooting bl;
    //public float bulletSpeed;
    public int Timer;
    public int reloadTimer;
    public int bulletSpread;

    public int cost;

    //AI handler
    public GameObject AImarker;
    public bool AIstatus;


    public Transform[] barrelArray;

    private void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        cam = camera.GetComponent<Camera>();

        AIstatus = true;
    }

    void Update()
    {

        if (AIstatus)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
            mousePos = new Vector2(GetClosestEnemy(enemies).position.x, GetClosestEnemy(enemies).position.y);
        }
        else
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        lookdir = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookdir.x, lookdir.y) * Mathf.Rad2Deg - 90f;

        transform.eulerAngles = new Vector3(0, 0, angle) * -1;



        if (Timer > reloadTimer)
        {
            if (Input.GetButton("Fire1") || AIstatus)
            {
                foreach (Transform barrel in barrelArray)
                {
                    Instantiate(bulletPrefab, barrel.position, Quaternion.Euler(0, 0, barrel.rotation.eulerAngles.z + Random.Range(-bulletSpread, bulletSpread)));
                }


                Timer = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        Timer++;

        
    }

    public void ChangeAIstate()
    {
        //AIstatus = true ? AIstatus = false : AIstatus = true;
        if (AIstatus)
        {
            AIstatus = false;
            AImarker.SetActive(false);
        }
        else
        {
            AIstatus = true;
            AImarker.SetActive(true);
        }
        Debug.Log("Mousedown event");
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
