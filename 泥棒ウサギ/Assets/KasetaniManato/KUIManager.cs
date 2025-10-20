using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KUIManager: MonoBehaviour
{

    int hp = 0;
    public GameObject lifeImage;         //HP�̐���\������Image
    public GameObject retryButton;       //���g���C�{�^��
    public GameObject mainImage;         //�摜������GameObject
    public GameObject inputPanel;        //�o�[�`�����p�b�h�ƍU���{�^����z�u��������p�l��
    public Sprite gameOverSpr;           //GAME OVER�摜 
    public Sprite life3Image;           //HP3�摜
    public Sprite life2Image;�@�@�@�@�@ //HP2�摜�@�@
    public Sprite life1Image;           //HP1�摜
    public Sprite life0Image;           //HP0�摜


    //HP�X�V
    void UpdateHP()
    {
        //Player�擾
        if (PlayerControll.gameState!="gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player!=null)
            {
                if(PlayerControll.player_hp!=hp )
                {
                    hp= PlayerControll.player_hp;
                    if(hp<=0)
                    {
                        lifeImage.GetComponent<Image>().sprite = life0Image;
                        //�v���C���[���S�I
                        retryButton.SetActive(true);                           //�{�^���\��
                        mainImage.SetActive(true);                             //�摜�\��
                                                                               //�摜��ݒ肷��
                        mainImage.GetComponent<Image>().sprite = gameOverSpr;
                        inputPanel.SetActive(false);                           //����UI��\��
                        PlayerControll.gameState = "gameend";                  //�Q�[���I��
                    }
                }

            }
            else if (hp == 1)
            {
                lifeImage.GetComponent<Image>().sprite = life1Image;
            }
            else if(hp==2)
            {
                lifeImage.GetComponent<Image>().sprite = life2Image;
            }
            else
            {
                lifeImage.GetComponent<Image>().sprite = life3Image;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
