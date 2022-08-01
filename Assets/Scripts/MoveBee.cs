using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBee : MonoBehaviour
{
    // 移動速度
    private float speed = 3.0f;

    // ボタン押しっぱなし判定
    private bool rightFlg = false;
    private bool leftFlg  = false;

    void Update()
    {
        // 蜂の移動
        Vector2 posObject = transform.position;
        if((Input.GetKey(KeyCode.LeftArrow) || leftFlg == true) && posObject.x >= -4.7f)
        {
            posObject.x -= speed * Time.deltaTime;
        }
        else if((Input.GetKey(KeyCode.RightArrow) || rightFlg == true) && posObject.x <= 4.7f)
        {
            posObject.x += speed * Time.deltaTime;
        }
        transform.position = posObject;
    }

    // タップによる移動判定
    public void OnRightButtonDown()
    {
        rightFlg = true;
    }

    public void OnRightButtonUp()
    {
        rightFlg = false;
    }

    public void OnLeftButtonDown()
    {
        leftFlg = true;
    }

    public void OnLeftButtonUp()
    {
        leftFlg = false;
    }
}
