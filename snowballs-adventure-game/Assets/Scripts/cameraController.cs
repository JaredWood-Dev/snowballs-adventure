using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public float minimumCameraHeight = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        gameObject.transform.position =
            new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, minimumCameraHeight, Single.PositiveInfinity), transform.position.z);
    }
}
