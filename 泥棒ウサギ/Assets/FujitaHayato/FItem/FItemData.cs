using UnityEngine;

//�A�C�e���̎��
public enum ItemType
{
    kyuuri, //���イ��
}

public class FItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeId = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //�ڐG
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (type == ItemType.kyuuri)
            {
                //���イ��
                ItemKeeper.haskyuuri += count;
            }

            //�A�C�e���擾���o
            //�����������
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //�A�C�e����Rigidbody2D������Ă���
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //�d�͂�߂�
            itemBody.gravityScale = 2.5f;
            //��ɒ��ˏグ�鉉�o
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5�b��ɍ폜
            Destroy(gameObject, 0.5f);

        }
    }
}