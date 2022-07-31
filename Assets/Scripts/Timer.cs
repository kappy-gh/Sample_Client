using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Timer : MonoBehaviour
{
    // 時間
    private float nowTime = 30.0f;

    // 時間を表示するテキスト
    public Text timeText;

    // ゲーム終了時判定
    private bool firstFlg = true;

    void Start()
    {
        // 時間を表示するテキストの初期化
        timeText.text = timeText.text = nowTime.ToString("F0");
    }

    void Update()
    {
        // 時間を表示
        nowTime -= Time.deltaTime;
        timeText.text = nowTime.ToString("F0");

        // 0sでゲーム終了
        if(nowTime <= 0f)
        {
            Time.timeScale = 0;
            if(firstFlg == true)
            {
                // ユーザー情報を取得
                this.GetComponent<SaveManager>().Load();

                // ランキングデータ取得
                this.GetComponent<UserRankingGetApi>().Get();

                firstFlg = false;
            }
        }
    }
}
