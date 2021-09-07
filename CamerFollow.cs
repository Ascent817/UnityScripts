using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (Input.mouseScrollDelta.y != 0)
        {
            if (gameObject.GetComponent<Camera>().orthographicSize < 1)
            {
                gameObject.GetComponent<Camera>().orthographicSize += Mathf.Abs(Input.mouseScrollDelta.y);
            }
            else
            {
                gameObject.GetComponent<Camera>().orthographicSize += -Input.mouseScrollDelta.y;
            }
    
        }
    }
}
