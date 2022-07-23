using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    // prefabを読み込む
    public GameObject _flower;
    public GameObject _bard;

    // オブジェクトの箱
    private GameObject Object;

    // オブジェクトの生成位置
    private float posX;
    Vector2 posObject;

    // 生成時間
    private float nowTime = 0f;
    private float interval = 1.3f;

    // オブジェクトを決める乱数
    private float numObject;

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム開始時最初のオブジェクトを生成
        posX = Random.Range(-5.0f, 5.0f);
        posObject = new Vector2(posX, 6.5f);
        Object = Instantiate(_flower, posObject, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;

        if(nowTime >= interval)
        {
            // オブジェクトを生成
            posX = Random.Range(-5.0f, 5.0f);
            posObject = new Vector2(posX, 6.5f);
            numObject = Random.Range(0f, 100f);
            if(numObject <= 65.0f)
            {
                Object = Instantiate(_flower, posObject, Quaternion.identity);
            }
            else
            {
                Object = Instantiate(_bard, posObject, Quaternion.identity);
            }
            nowTime = 0f;
        }

    }
}
