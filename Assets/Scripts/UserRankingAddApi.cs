using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Networking;

// ユーザーランキング登録のAPI
public class UserRankingAddApi : MonoBehaviour
{
    [Serializable]
    private sealed class PostParams
    {
        public string uuid;
        public string user_name;
        public int score;
    }

    string requestURL = "http://localhost:8002/laravel/public/api/user/ranking/add";

    // コンポーネントを読み込む
    private SaveManager saveManager;
    private UserRankingGetApi userRankingGetApi;

    void Start()
    {
        // コンポーネントを読み込む
        saveManager = this.GetComponent<SaveManager>();
        userRankingGetApi = this.GetComponent<UserRankingGetApi>();
    }

    private IEnumerator PostData(string uuid, string user_name, int score)
    {
        var data  = new PostParams();
        data.uuid = uuid;
        data.user_name = user_name;
        data.score     = score;
        var json       = JsonUtility.ToJson(data);
        var postData   = Encoding.UTF8.GetBytes(json);

        using(var request = new UnityWebRequest(requestURL, UnityWebRequest.kHttpVerbPOST))
        {
            request.uploadHandler   = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
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
                // 新規ユーザーならユーザーデータを保存
                if(uuid == null)
                {
                    string new_uuid = request.downloadHandler.text;
                    saveManager.Save(new_uuid);
                }

                // ランキング再表示
                userRankingGetApi.Get();
            }
        }
    }

    public void Post(string uuid, string user_name, int score)
    {
        StartCoroutine(PostData(uuid, user_name, score));
    }
}
