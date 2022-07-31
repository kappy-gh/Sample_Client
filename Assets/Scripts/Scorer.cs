using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    // スコア
    private int score = 0;

    // スコアを表示するテキスト
    public Text scoreText;
    public Text nowScoreText;
    public Text highScoreText;

    // 結果パネル
    public GameObject resultPanel;

    // タイトル遷移ボタン
    public GameObject titleButton;

    // ランキング生成
    public GameObject _rankData;
    private GameObject rankData;
    public Transform content;

    // ユーザーデータ
    private string uuid;

    // ユーザー名テキスト
    public InputField userNameText;

    // 登録ボタン
    public GameObject enterButton;

    void Start()
    {
        // スコアを表示するテキストの初期化
        scoreText.text = score.ToString();
        highScoreText.text = "0";
    }

    // スコア加算
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // スコアリセット
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    //ランキング作成
    public void MakeRanking(List<int> ranks, List<string> user_names, List<int> scores)
    {
        resultPanel.SetActive(true);
        nowScoreText.text = nowScoreText.text = score.ToString();
        titleButton.SetActive(true);

        // 行を生成
        foreach(int rank in ranks)
        {
            rankData = Instantiate(_rankData, transform.position, Quaternion.identity, content);
            rankData.transform.FindChild("Rank").gameObject.GetComponent<Text>().text = rank.ToString();
            rankData.transform.FindChild("UserName").gameObject.GetComponent<Text>().text = user_names[rank - 1];
            rankData.transform.FindChild("Score").gameObject.GetComponent<Text>().text = scores[rank - 1].ToString();
        }
    }

    // ユーザー結果を作成
    public void MakeUser(string now_uuid, string user_name, int high_score)
    {
        uuid = now_uuid;
        userNameText.text = user_name;
        userNameText.interactable = false;
        highScoreText.text = high_score.ToString();

        if(score <= high_score)
        {
            enterButton.GetComponent<Button>().interactable = false;
        }
    }

    // 登録
    public void OnEnter()
    {
        string user_name = userNameText.text;
        userNameText.interactable = false;
        enterButton.GetComponent<Button>().interactable = false;

        // ランキング登録
        this.GetComponent<UserRankingAddApi>().Post(uuid, user_name, score);

        highScoreText.text = score.ToString();

        for(int i = 0; i < content.childCount; i++)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
    }
}
