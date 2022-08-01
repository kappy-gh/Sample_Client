using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        if(this.transform.position.y < -7.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
