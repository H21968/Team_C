using UnityEngine;

public class FTitleBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ƒ^ƒCƒgƒ‹BGMÄ¶
        FSoundManager.soundManager.PlayBgm(BGMType.Title);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
