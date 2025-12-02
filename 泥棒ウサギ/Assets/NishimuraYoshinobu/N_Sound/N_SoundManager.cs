using UnityEngine;

public class N_SoundManager : MonoBehaviour
{
    public static N_SoundManager N_Instance;

    public AudioSource BGM_Source;
    public AudioClip [] BGM_Clip;

    private void Awake()
    {
        if (N_Instance == null)
        {
            N_Instance = this;              // 自分自身を唯一の N_Instance に登録
            DontDestroyOnLoad(gameObject);  // シーンを変えても破棄しない
        }
        else
        {
            Destroy(gameObject);            //重複して BGM が二重再生されるのを防ぐ
        }
    }
    public void N_Play_BGM(AudioClip clip)
    {
        //何もしない
        if (clip == null)
        {
            Debug.LogWarning("N_Play_BGM が呼ばれたけど、AudioClip が NULL です。BGM は再生しません。");
            N_BGM_Stop();  //BGMを止めておく
            return;
        }
        // すでに同じ曲を再生中なら再生しない
        if (BGM_Source.clip == clip && BGM_Source.isPlaying)
        {
            return;
        }
        BGM_Play(clip);
    }

    void BGM_Play(AudioClip clip)
    {
        //新しいBGMを再生
        BGM_Source.Stop();          // 前のBGMを止める
        BGM_Source.clip = clip;     // 新しい曲に差し替え
        BGM_Source.Play();          // 再生開始
    }
    public void N_BGM_Stop()
    {
        if (BGM_Source != null && BGM_Source.isPlaying)
        {
            BGM_Source.Stop();
        }
    }
}
