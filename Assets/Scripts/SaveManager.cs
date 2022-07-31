using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class SaveManager : MonoBehaviour
{
    string filePath;
    SaveData save;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/" + ".savedata.json";
        save = new SaveData();

        // ユーザーデータの削除（デバッグ用）
        // File.Delete(filePath);
        
    }

    // ユーザーデータを保存する
    public void Save(string uuid)
    {
        save.uuid = uuid;
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
    }

    // ユーザーデータを読み込む
    public void Load()
    { 
        // 既存ユーザー
        if(File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);

            // ユーザーデータ取得
            this.GetComponent<UserInfoGetApi>().Post(save.uuid);
        }
    }
}
