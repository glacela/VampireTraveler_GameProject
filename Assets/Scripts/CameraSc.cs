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

    void LateUpdate()
    {
        Vector3 temp = transform.position; // Current camera pos stored
        float x = playerTransfrom.position.x;

        if (x > 0 && x < 18.5)
        {
            temp.x = x; // Stored pos to player pos
        }
        temp.y = playerTransfrom.position.y;

        temp.y += offset;

        transform.position = temp; // Stored player pos to camera pos
    }
}
