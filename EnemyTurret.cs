using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    
    GameObject target;
    Vector2 lookdir;
    public GameObject bulletPrefab;
    ProjectileShooting bl;
    //public float bulletSpeed;
    public int Timer;
    public int reloadTimer;
    public int bulletSpread;
    float bulletSpeed;

    public Transform[] barrelArray;

    [SerializeField]Vector2 Direction;

    private void Start()
    {
        bulletSpeed = bulletPrefab.GetComponent<ProjectileShooting>().speed;
    }

    void Update()
    {
        target = GameObject.Find("Ship");
        //lookdir = new Vector2(target.transform.position.x, target.transform.position.y) - new Vector2(transform.position.x, transform.position.y);
        //float angle = Mathf.Atan2(lookdir.x, lookdir.y) * Mathf.Rad2Deg - 90f;

        //transform.eulerAngles = new Vector3(0, 0, angle) * -1;
        if (InterceptionDirection(new Vector2(target.transform.position.x, target.transform.position.y), transform.position, target.GetComponent<Rigidbody2D>().velocity, bulletSpeed, out var direction))
        {
            var angle1 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle1, Vector3.forward);
        }


        if (Timer > reloadTimer)
        {

            foreach (Transform barrel in barrelArray)
            {
                var instance = Instantiate(bulletPrefab, barrel.position, Quaternion.Euler(0, 0, barrel.rotation.eulerAngles.z - 90 + Random.Range(-bulletSpread, bulletSpread)));
                instance.GetComponent<ProjectileShooting>().manualRot = true;
                instance.GetComponent<ProjectileShooting>().faceDir = direction;
                Direction = direction;
                if (!InterceptionDirection(new Vector2(target.transform.position.x, target.transform.position.y), transform.position, target.GetComponent<Rigidbody2D>().velocity, bulletSpeed, out var temp))
                {
                    instance.GetComponent<ProjectileShooting>().manualRot = false;
                }

            }


            Timer = 0;
            
        }

    }

    private void FixedUpdate()
    {
        Timer++;
    }

    public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {

        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;

        if (Math.SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2) == 0)
        {
            result = Vector2.zero;
            return false;
        }

        var dA = Mathf.Max(root1, root2);
        var t = dA / sB; 
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;

    }

}

public class Math
{

    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }

        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }

}
