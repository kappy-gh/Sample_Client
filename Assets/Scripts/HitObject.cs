using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    // スコアの取得
    public GameObject canvas;
    private Scorer scorer;

    void Start()
    {
        // スコアの取得
        scorer = canvas.GetComponent<Scorer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

        if(other.gameObject.tag == "Flower")
        {
            scorer.AddScore();
        }
        else if(other.gameObject.tag == "Bard")
        {
            scorer.ResetScore();
        }
    }
}
