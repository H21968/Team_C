using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasGoldKeys = 0; //このアイテムの初期の個数
    public static int hasSilverKeys = 0;
    public static int hasArrows = 0;
    public static int hasLights = 0;
    //ここから使ってるもの
    //野菜---------------------------------
    public static int haskyuuri = 0;
    public static int haskyabetu = 0;
    public static int hasninjin = 0;
    public static int hastamanegi = 0;
    //果物---------------------------------
    public static int hassakuranbo = 0;
    public static int hasringo = 0;
    public static int hasnashi = 0;
    public static int hasorange = 0;
    //アイテム-----------------------------
    public static int haskagi = 0;
    public static int hasnakama = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ゲームがスタートしたときアイテムのカウントを0にする
        //野菜-----------------
        haskyuuri = 0;
        haskyabetu = 0;
        hasninjin = 0;
        hastamanegi = 0;
        //果物-----------------
        hassakuranbo = 0;
        hasringo = 0;
        hasnashi = 0;
        hasorange = 0;
        //その他---------------
        haskagi = 0;
        hasnakama = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
