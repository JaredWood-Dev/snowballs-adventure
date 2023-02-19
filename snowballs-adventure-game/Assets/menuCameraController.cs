using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCameraController : MonoBehaviour
{
    public Vector2 originPosition;
    void Update()
    {
        transform.position = Vector2.Lerp(new Vector2(originPosition.x , originPosition.y + 5),
            new Vector2(originPosition.x - 5, originPosition.y - 5), 5);
    }
}
