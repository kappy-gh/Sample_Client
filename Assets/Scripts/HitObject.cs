using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitObject : MonoBehaviour
{
    // スコア
    private int score = 0;

    // スコアを表示するテキスト
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // スコアを表示するテキストの初期化
        scoreText.text = scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         Destroy(other.gameObject);

        if(other.gameObject.tag == "Flower")
        {
           score++;
        }
        else if(other.gameObject.tag == "Bard")
        {
            score = 0;
        }
        scoreText.text = scoreText.text = score.ToString();
    }
}
