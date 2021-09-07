using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{

    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;
    public GameObject turret5;
    public GameObject turret6;
    public GameObject turret7;
    public GameObject turret8;
    public GameObject turret9;
    public GameObject turret10;

    public GameObject[] turretArray = new GameObject[10];

    Transform tempPos;

    void Start()
    {
        turretArray[0] = turret1;
        turretArray[1] = turret2;
        turretArray[2] = turret3;
        turretArray[3] = turret4;
        turretArray[4] = turret5;
        turretArray[5] = turret6;
        turretArray[6] = turret7;
        turretArray[7] = turret8;
        turretArray[8] = turret9;
        turretArray[9] = turret10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTurret(GameObject replacement, string turretNum, out GameObject Current)
    {

        if (turretNum == "1")
        {
            Current = turret1;
            tempPos = turret1.transform;
            Destroy(turret1);
            turret1 = Instantiate(replacement, gameObject.transform);
            turret1.transform.position = tempPos.position;
            turret1.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "2")
        {
            Current = turret2;
            tempPos = turret2.transform;
            Destroy(turret2);
            turret2 = Instantiate(replacement, gameObject.transform);
            turret2.transform.position = tempPos.position;
            turret2.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "3")
        {
            Current = turret3;
            tempPos = turret3.transform;
            Destroy(turret3);
            turret3 = Instantiate(replacement, gameObject.transform);
            turret3.transform.position = tempPos.position;
            turret3.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "4")
        {
            Current = turret4;
            tempPos = turret4.transform;
            Destroy(turret4);
            turret4 = Instantiate(replacement, gameObject.transform);
            turret4.transform.position = tempPos.position;
            turret4.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "5")
        {
            Current = turret5;
            tempPos = turret5.transform;
            Destroy(turret5);
            turret5 = Instantiate(replacement, gameObject.transform);
            turret5.transform.position = tempPos.position;
            turret5.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "6")
        {
            Current = turret6;
            tempPos = turret6.transform;
            Destroy(turret6);
            turret6 = Instantiate(replacement, gameObject.transform);
            turret6.transform.position = tempPos.position;
            turret6.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "7")
        {
            Current = turret7;
            tempPos = turret7.transform;
            Destroy(turret7);
            turret7 = Instantiate(replacement, gameObject.transform);
            turret7.transform.position = tempPos.position;
            turret7.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "8")
        {
            Current = turret8;
            tempPos = turret8.transform;
            Destroy(turret8);
            turret8 = Instantiate(replacement, gameObject.transform);
            turret8.transform.position = tempPos.position;
            turret8.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "9")
        {
            Current = turret9;
            tempPos = turret9.transform;
            Destroy(turret9);
            turret9 = Instantiate(replacement, gameObject.transform);
            turret9.transform.position = tempPos.position;
            turret9.transform.rotation = tempPos.rotation;
        }
        else if (turretNum == "10")
        {
            Current = turret10;
            tempPos = turret10.transform;
            Destroy(turret10);
            turret10 = Instantiate(replacement, gameObject.transform);
            turret10.transform.position = tempPos.position;
            turret10.transform.rotation = tempPos.rotation;
        }
        else
        {
            Debug.LogError("Fatal Case Error: Requested slot does not exist. Requested slot will be returned as null");
            Current = null;
        }



    }

    public void QueryTurret(string turretNum, out GameObject CurrentRequested)
    {

        if (turretNum == "1")
        {
            CurrentRequested = turret1;
        }
        else if (turretNum == "2")
        {
            CurrentRequested = turret2;
        }
        else if (turretNum == "3")
        {
            CurrentRequested = turret3;
        }
        else if (turretNum == "4")
        {
            CurrentRequested = turret4;
        }
        else if (turretNum == "5")
        {
            CurrentRequested = turret5;
        }
        else if (turretNum == "6")
        {
            CurrentRequested = turret6;
        }
        else if (turretNum == "7")
        {
            CurrentRequested = turret7;
        }
        else if (turretNum == "8")
        {
            CurrentRequested = turret8;
        }
        else if (turretNum == "9")
        {
            CurrentRequested = turret9;
        }
        else if (turretNum == "10")
        {
            CurrentRequested = turret10;
            ;
        }
        else
        {
            Debug.LogError("Fatal Case Error: Requested slot does not exist. Requested slot will be returned as null");
            CurrentRequested = null;
        }
    }
}
