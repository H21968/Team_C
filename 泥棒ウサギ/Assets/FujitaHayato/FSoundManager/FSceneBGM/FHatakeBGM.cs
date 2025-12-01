using UnityEngine;

public class FHatakeBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //畑ステージBGM再生
        FSoundManager.soundManager.PlayBgm(BGMType.InHatake);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
