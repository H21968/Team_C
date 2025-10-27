using UnityEngine;
using UnityEngine.UI;

public class KItemManager : MonoBehaviour
{
    int hasSilverKeys = 0;                //銀の鍵の数
    //int hasGoldKeys = 0;                  //金の鍵の数
    public GameObject SilverKeyText;      //銀の鍵数を表示するテキスト
    //public GameObject GoldKeyText;        //金の鍵数を表示するテキスト


    // Update is called once per frame
    void UpdateItemCount()
    {
        //銀の鍵
        if(hasSilverKeys!=ItemKeeper.hasSilverKeys)
        {
            SilverKeyText.GetComponent<Text>().text = ItemKeeper.hasSilverKeys.ToString();
            hasSilverKeys = ItemKeeper.hasSilverKeys;
        } 
    }
}
