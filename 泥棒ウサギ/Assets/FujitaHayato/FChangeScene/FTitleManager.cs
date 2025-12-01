using UnityEngine;
using UnityEngine.SceneManagement;  //シーンの切り替えに必要


public class FTitleManager : MonoBehaviour
{
    public string sceneName;    //読み込むシーン名

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Zキーが押されたらシーンが切り替わる
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(sceneName);

            //SE再生
            FSoundManager.soundManager.SEPlay(SEType.ZKey);
        }
    }

    //シーンを読み込む
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
