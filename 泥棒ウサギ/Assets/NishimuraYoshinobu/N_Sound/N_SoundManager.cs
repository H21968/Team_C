using UnityEngine;

/// <summary>
/// 敵エネミー接敵時に鳴る曲を管理する
/// </summary>
public class N_SoundManager : MonoBehaviour
{
    /// <summary>
    /// BGM再生のAudioSource
    /// </summary>
    public AudioSource BGM_Source;

    /// <summary>
    /// 敵が接近している時のBGM
    /// </summary>
    public AudioClip enemy_access;           

    public bool isActive = false;


    private void Awake()
    {
     
    }
    public void N_Play_BGM(AudioClip clip)
    {
        // 何もしない
        if (clip == null)
        {
            Debug.LogWarning("N_Play_BGM が呼ばれた、AudioClip が NULL です。BGM は再生できません");
            N_BGM_Stop();  // BGMを止める
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
        // 新しいBGMを再生
        BGM_Source.Stop();          // 前のBGMを止める
        BGM_Source.clip = clip;     // 新しい曲に差し替え
        BGM_Source.Play();          // 再生開始
    }
    public void N_BGM_Stop()
    {
        if (BGM_Source != null && BGM_Source.isPlaying)
        {
            BGM_Source.Stop(); // BGMを止める
        }
    }
}
