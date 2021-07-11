using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour
{
    private Transform playerTransfrom;
    
    private float offset = 2.5f;

    void Start()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position; // Current camera pos stored
        float x = playerTransfrom.position.x;
        float y = playerTransfrom.position.y;

        if (x > 0 && x < 18.5)
        {
            temp.x = x; // Stored pos to player pos
        }
        temp.y = playerTransfrom.position.y;

        temp.y += offset;
        if (temp.y > 3.3)
        {
            temp.y = 3.3f;
        }
        if (temp.y < 0)
        {
            temp.y = 0;
        }
        transform.position = temp; // Stored player pos to camera pos
    }
}
