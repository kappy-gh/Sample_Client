using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 時間
    private float nowTime = 30.0f;

    // 時間を表示するテキスト
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        // 時間を表示するテキストの初期化
        timeText.text = timeText.text = nowTime.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        // 時間を表示
        nowTime -= Time.deltaTime;
        timeText.text = nowTime.ToString("F0");

        // 0sでゲーム終了
        if(nowTime <= 0f)
        {
            Time.timeScale = 0;
        }
    }
}
