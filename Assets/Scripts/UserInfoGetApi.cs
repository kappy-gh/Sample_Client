using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Networking;

// ユーザー情報取得のAPI
public class UserInfoGetApi : MonoBehaviour
{
    [Serializable]
    private sealed class PostParams
    {
        public string uuid;
    }

    [Serializable]
    public class InfoParams
    {
        public InfoParam[] responseParams;
    }

    [Serializable]
    public class InfoParam
    {
        public string user_name;
        public int high_score;
    }

    string requestURL = "http://localhost:8002/laravel/public/api/user/info/get";

    private IEnumerator PostData(string uuid)
    {
        var data = new PostParams();
        data.uuid = uuid;
        var json     = JsonUtility.ToJson(data);
        var postData = Encoding.UTF8.GetBytes(json);

        using(var request = new UnityWebRequest(requestURL, UnityWebRequest.kHttpVerbPOST))
        {
            request.uploadHandler = new UploadHandlerRaw(postData);
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
                var jsonParam = request.downloadHandler.text;
                var userInfos = JsonUtility.FromJson<InfoParams>(jsonParam);

                string user_name = userInfos.responseParams[0].user_name;
                int high_score = userInfos.responseParams[0].high_score;

                this.GetComponent<Scorer>().MakeUser(uuid, user_name, high_score);
            }
        }
    }

    public void Post(string uuid)
    {
        StartCoroutine(PostData(uuid));
    }
}
