using UnityEngine;
using UnityEngine.UI;

public class KItemManager : MonoBehaviour
{
    int hasSilverKeys = 0;                //��̌��̐�
    //int hasGoldKeys = 0;                  //���̌��̐�
    public GameObject SilverKeyText;      //��̌�����\������e�L�X�g
    //public GameObject GoldKeyText;        //���̌�����\������e�L�X�g


    // Update is called once per frame
    void UpdateItemCount()
    {
        //��̌�
        if(hasSilverKeys!=ItemKeeper.hasSilverKeys)
        {
            SilverKeyText.GetComponent<Text>().text = ItemKeeper.hasSilverKeys.ToString();
            hasSilverKeys = ItemKeeper.hasSilverKeys;
        } 
    }
}
