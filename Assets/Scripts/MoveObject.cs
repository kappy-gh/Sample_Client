using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // 移動速度
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posObject = transform.position;
        posObject.y -= speed * Time.deltaTime;
        transform.position = posObject;
    }
}
