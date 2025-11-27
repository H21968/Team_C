using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FMiseGameUIManager : MonoBehaviour
{
    int hassakuranbo = 0;              //さくらんぼの数
    int haskagi = 0;                   //鍵の数
    public GameObject sakuranboText;   //さくらんぼの数を表示するText
    public GameObject kagiText;        //鍵の数を表示するText

    //アイテム数更新
    void UpdateItemCount()
    {
        //さくらんぼ
        if (hassakuranbo != ItemKeeper.hassakuranbo)
        {
            sakuranboText.GetComponent<Text>().text = ItemKeeper.hassakuranbo.ToString();
        }

        //鍵
        if (haskagi != ItemKeeper.haskagi)
        {
            kagiText.GetComponent<Text>().text = ItemKeeper.haskagi.ToString();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateItemCount();  //アイテム数更新
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemCount();  //アイテム数更新
    }
}
