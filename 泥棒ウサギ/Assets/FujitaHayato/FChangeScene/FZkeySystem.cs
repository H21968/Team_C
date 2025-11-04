using UnityEngine;
using UnityEngine.SceneManagement;  //シーンの切り替えに必要
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FZkeySystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Zキー押下
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 選択中のオブジェクト取得
            GameObject nowObj = EventSystem.current.currentSelectedGameObject;

            // 選択中のオブジェクトが存在すれば
            if (nowObj != null)
            {
                // Button コンポーネントを取得
                Button btn = nowObj.GetComponent<Button>();

                // ボタンがあればクリックイベントを呼び出す
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
                else
                {
                    // Button以外でもSubmitイベントを送る方法
                    ExecuteEvents.Execute(nowObj, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                }
            }
        }
    }
}
