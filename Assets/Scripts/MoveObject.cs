using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // 移動速度
    public float speed;

    void Update()
    {
        Vector2 posObject = transform.position;
        posObject.y -= speed * Time.deltaTime;
        transform.position = posObject;
    }
}
