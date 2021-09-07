using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public float range;
    public int damage;
    public float speed;
    public float growAmount;
    SpriteRenderer sp;
#pragma warning disable IDE0052 // Remove unread private members
    public bool endAnimation = false;
    public bool manualRot;
    public Vector2 faceDir;
    public bool startRot = false;

    Vector2 startPos;
    [SerializeField] float magnitude;

    private void Start()
    {
        startPos = transform.position;

        if (manualRot)
        {
            //transform.eulerAngles = new Vector3(0, 0, Vector2.Angle(transform.position, faceDir));
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90 * -1);
        }

        
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        if (!startRot)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        transform.position += transform.up * speed * Time.deltaTime;

        magnitude = startPos.magnitude;

        
    }

    private void FixedUpdate()
    {
        if ((new Vector2(transform.position.x, transform.position.y) - startPos).magnitude > range)
        {
            EndAnimation();
        }
        else if (endAnimation)
        {
            EndAnimation();
        }
    }



    void EndAnimation()
    {
        endAnimation = true;
        transform.localScale = new Vector3(transform.localScale.x + growAmount, transform.localScale.y + (growAmount * 2), 0);
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - growAmount);

        if (sp.color.a < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            endAnimation = true;
        }       
    }
}
