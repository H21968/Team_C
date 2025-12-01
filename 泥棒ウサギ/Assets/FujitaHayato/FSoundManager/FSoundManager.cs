using UnityEngine;

//BGMタイプ
public enum BGMType
{
    None,   //なし
    Title,  //タイトル
    InGame, //ゲーム中
    InBoss, //ボス線
}
//SEタイプ
public enum SEType
{
    GameClear,  //ゲームクリア
    GameOver,   //ゲームオーバー
}

public class FSoundManager : MonoBehaviour
{
    public AudioClip bgmInTitle;    //タイトルBGM
    public AudioClip bgmInGame;     //ゲーム中
    public AudioClip bgmInBoss;     //ボス線BGM
    public AudioClip meGameClear;   //ゲームクリア
    public AudioClip meGameOver;    //ゲームオーバー

    public static FSoundManager soundManager;   //最初のSoundManagerを保存する変数

    public static BGMType playingBGM = BGMType.None;    //再生中のBGM

    private void Awake()
    {
        //BGM再生
        if(soundManager==null)
        {
            soundManager = this;    //static偏すに自分を保存する
            //シーンが変わってもゲームオブジェクトを破棄しない
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    //ゲームオブジェクトを破棄
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BGM設定
    public void PlayBgm(BGMType type)
    {
        if(type !=playingBGM)
        {
            playingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();
            if(type==BGMType.Title)
            {
                audio.clip = bgmInTitle;    //タイトル
            }
            else if (type == BGMType.InGame)
            {
                audio.clip = bgmInGame;    //ゲーム中
            }
            else if (type == BGMType.InBoss)
            {
                audio.clip = bgmInBoss;    //ゲーム中
            }
            audio.Play();
        }
    }
    //BGM停止
    public void StopBgm()
    {
        GetComponent<AudioSource>().Stop();
        playingBGM = BGMType.None;
    }

    //SE再生
    public void SEPlay(SEType type)
    {
        if(type ==SEType.GameClear)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameClear);   //ゲームクリア
        }
        else if (type == SEType.GameOver)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameOver);   //ゲームクリア
        }
    }

}
