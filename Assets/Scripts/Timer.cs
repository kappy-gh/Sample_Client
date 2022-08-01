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

    // コンポーネントを読み込む
    private SaveManager saveManager;
    private UserRankingGetApi userRankingGetApi;

    void Start()
    {
        // 時間を表示するテキストの初期化
        timeText.text = timeText.text = nowTime.ToString("F0");

        // コンポーネントを読み込む
        saveManager = this.GetComponent<SaveManager>();
        userRankingGetApi = this.GetComponent<UserRankingGetApi>();
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
                // ユーザー保存データを取得
                saveManager.Load();

                // ランキングデータ取得
                userRankingGetApi.Get();

                firstFlg = false;
            }
        }
    }
}
