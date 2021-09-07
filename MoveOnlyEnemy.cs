using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnlyEnemy : MonoBehaviour
{

    public SpriteRenderer sp;
    GameObject target;
    public float speed;
    public Color startColor;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        startColor = sp.color;
        target = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MoveToTarget();
        
        if (sp.color.r < 255)
        {
            sp.color = new Color(sp.color.r + ((startColor.r - sp.color.r)/2), sp.color.g + ((startColor.g - sp.color.g) / 2), sp.color.g + ((startColor.b - sp.color.b) / 2));
        }
    }

    void MoveToTarget()
    {
        

        transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }
}
