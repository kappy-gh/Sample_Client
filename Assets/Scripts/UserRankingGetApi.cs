using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Networking;

// ランキング情報取得のAPI
public class UserRankingGetApi : MonoBehaviour
{
    [Serializable]
    public class ResponseParams
    {
        public ResponseParam[] responseParams;
    }

    [Serializable]
    public class ResponseParam
    {
        public string user_name;
        public int score;
    }

    string requestURL = "http://localhost:8002/laravel/public/api/user/ranking/get";

    // コンポーネントを読み込む
    private Scorer scorer;

    void Start()
    {
        // コンポーネントを読み込む
        scorer = this.GetComponent<Scorer>();
    }
    
    private IEnumerator GetData()
    {
        using(var request = UnityWebRequest.Get(requestURL))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else if(request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var json      = request.downloadHandler.text;
                var rankLists = JsonUtility.FromJson<ResponseParams>(json);

                List<int> ranks         = new List<int>();
                List<string> user_names = new List<string>();
                List<int> scores        = new List<int>(); 

                int num = 0;
                foreach (var rankList in rankLists.responseParams)
                {
                    ranks.Add(num + 1);
                    user_names.Add(rankList.user_name);
                    scores.Add(rankList.score);
                    num++;
                }
                scorer.MakeRanking(ranks, user_names, scores);
            }
        }
    }

    public void Get()
    {
        StartCoroutine(GetData());
    }
}
