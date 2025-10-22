using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���̎��
public enum ItemTypea
{
    arrow,        //��
    GoldKey,      //���̌�
    SilverKey,    //��̌�
    Life,         //���C�t 
    Light,        //���C�g
}

public class ItemData : MonoBehaviour
{
    public ItemTypea type;
    public int count = 1;
    public int arrangeId = 0;

    //
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�ڐG
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(type==ItemTypea.GoldKey)
            {
                //���̌�
                ItemKeeper.hasGoldKeys += count;
            }
            else if(type==ItemTypea.SilverKey)
            {
                //��̌�
                ItemKeeper.hasSilverKeys += count;
            }
            else if (type == ItemTypea.arrow)
            {
                //��
               // ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                //ItemKeeper.hasArrows += count;
            }
            else if(type==ItemTypea.Life)
            {
                //���C�t
                if (PlayerControll.player_hp<3)
                {
                    //HP��3�ȉ��̏ꍇ���Z����
                    PlayerControll.player_hp++;
                }
            }
            else if (type == ItemTypea.Light)
            {
                //���C�g
                ItemKeeper.hasLights += count;
                GameObject.FindObjectOfType<PlayerLightController>().LightUpdate();
            }
            //�A�C�e���擾���o
            //�����������
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //�A�C�e����Rigidbody2D������Ă���
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //�d�͂�߂�
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5�b��ɍ폜
            Destroy(gameObject, 0.5f);
        }
    }
}
