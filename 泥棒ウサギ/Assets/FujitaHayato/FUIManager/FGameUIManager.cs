using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FGameUIManager : MonoBehaviour
{
    int haskyuuri = 0;              //���イ��̐�
    public GameObject kyuuriText;   //���イ��̐���\������Text

    //�A�C�e�����X�V
    void UpdateItemCount()
    {
        //���イ��
        if(haskyuuri !=ItemKeeper.haskyuuri)
        {
            kyuuriText.GetComponent<Text>().text = ItemKeeper.haskyuuri.ToString();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateItemCount();  //�A�C�e�����X�V
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemCount();  //�A�C�e�����X�V
    }
}
