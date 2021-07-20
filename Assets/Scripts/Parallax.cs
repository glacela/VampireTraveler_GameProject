using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] bgs;
    private Transform cam;

    public float p_amount = 1f;
    private float[] scalers;

    private Vector3 prevCamPos;
    
    // Awake is called before Start.
    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        prevCamPos = cam.position;
        scalers = new float[bgs.Length];

        for (int i = 0; i < bgs.Length; i++)
        {
            scalers[i] = bgs[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < bgs.Length; i++)
        {
            float parallax = (prevCamPos.x - cam.position.x) * scalers[i];
            float bgTargetPosX = bgs[i].position.x + parallax;
            Vector3 bgTargetPos = new Vector3(bgTargetPosX, bgs[i].position.y, bgs[i].position.z);
            bgs[i].position = Vector3.Lerp(bgs[i].position, bgTargetPos, p_amount * Time.deltaTime);
        }
        prevCamPos = cam.position;
    }
}
