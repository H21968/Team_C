using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI���g���̂ɕK�v

public class FClearManager : MonoBehaviour
{
    public GameObject mainImage;    //�摜������GameObject
    public Sprite gameClearSpr;     //GAMECLEAR�摜
    public Sprite gameOverSpr;      //GAMEOVER�摜

    public GameObject ufo;          //ufo�̃I�u�W�F�N�g��G��p

    Image titleImage;               //�摜��\�����Ă���Image�R���|�[�l���g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�摜���\���ɂ���
        Invoke("InactiveImage", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //���イ����������ufo���o�����鏈��
        //�ŏ�ufo���\���ɂ���p
        ufo.SetActive(false);
        //���イ��̐����P�̎�ufo�������p
        if(ItemKeeper.haskyuuri>=2)
        {
            ufo.SetActive(true);    //ufo���o�Ă���
        }


        //�Q�[���N���A������
        if (PlayerControll.gameState=="gameclear")
        {
            mainImage.SetActive(true);      //�摜��\������

            mainImage.GetComponent<Image>().sprite = gameClearSpr;    //�摜��ݒ肷��
        }
        //�Q�[���I�[�o�[�ɂȂ�����
        else if (PlayerControll.gameState == "gameover")
        {
            mainImage.SetActive(true);      //�摜��\������

            mainImage.GetComponent<Image>().sprite = gameOverSpr;    //�摜��ݒ肷��
        }

        else if(PlayerControll.gameState=="playing")
        {
            //�Q�[����
        }
    }
    //�摜���\���ɂ���
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
