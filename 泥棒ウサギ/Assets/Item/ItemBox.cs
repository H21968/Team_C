using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;        //�J�����摜
    public GameObject itemPrefab;   //�o�Ă���A�C�e���̃v���n�u
    public bool isClosed = true;    //ture=�܂��Ă��� false=�J���Ă���
    public int arrangeId = 0;       //�z�u�̎��ʂɎg��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (isClosed && collision.gameObject.tag == "player")
        {
            //�����܂��Ă����ԂŃv���C���[�ɐڐG
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;//�J���Ă����Ԃɂ���
            if (itemPrefab != null)
            {
                //�A�C�e�����v���n�u������
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
