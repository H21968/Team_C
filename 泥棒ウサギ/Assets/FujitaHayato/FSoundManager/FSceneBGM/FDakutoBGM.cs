using UnityEngine;

public class FDakutoBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //地下ステージBGM再生
        FSoundManager.soundManager.PlayBgm(BGMType.InDakuto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
