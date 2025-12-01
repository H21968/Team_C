using UnityEngine;

public class FMiseBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //店ステージBGM再生
        FSoundManager.soundManager.PlayBgm(BGMType.InMise);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
