using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//�ؾ�� ����
enum State
{

}

//�ؾ�� ����
enum BungOType
{
    Basic
}

public class Mold : MonoBehaviour
{
    public Sprite[] sprite_;

    private int id_ = 0; // ���� ���, � �ؾ���� ����
    private int state_ = 0;
    public float cookingDegree_ = 0; // ���� ����
    private float speed_ = 5;

    private SpriteRenderer bung_;


    void Awake()
    {
        bung_ = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() //���߿� ������Ʈ ���� gamemanager���� playing�� �� ȣ��ǰ�
    {
        if (Input.GetMouseButtonDown(0)) //�׳� Ŭ������ ��
        {
            Debug.Log("Click!");
            if (cookingDegree_ > 100)
            {
                GetBungOPang();
            }
            else if (cookingDegree_ > 50)
            {
                Flip();
            }
            else
            {
                SetBungOPangID(1);
            }
        }

        Cooking();
    }

    void SetBungOPangID(int id)
    {
        id_ = id;
    }

    void Flip()
    {
        if(bung_.flipY) bung_.flipY = false;
        else bung_.flipY = true;
    }

    void GetBungOPang()
    {
        //����

        //�ʱ�ȭ
        id_ = 0;
        state_ = 0;
        cookingDegree_ = 0;
        bung_.sprite = sprite_[0];
        //�̹��� �ʱ�ȭ
    }

    void Cooking()
    {
        if (id_ == 0) return; //�ƹ��͵� �ȱ��� ������ return

        //���� ������ cooking ������Ʈ
        cookingDegree_ += speed_ * Time.deltaTime;

        if (cookingDegree_ > 170)
        {
            bung_.sprite = sprite_[4];
        }
        else if (cookingDegree_ > 100)
        {
            bung_.sprite = sprite_[id_];
        }
        else if (cookingDegree_ > 50)
        {
            //�� �;���
        }
        else
        {
            bung_.sprite = sprite_[1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {-
        if (id_ == 0 && Input.GetMouseButtonUp(0))
        {
            //id ����, ���� ��� �ִ� �ؾ� ����
            SetBungOPangID(1);
            //��� �� ���̱�
        }
    }
}

/*
 * ���尡 �ؾ� �� ����
 * 1. �÷��̾� �Է� ó��
 *  a. ��� �ֱ�
 *  b. ������
 *  c. �ϼ���Ű��
 *  
 * 2. �ð��� ���� ���� ����
 *  a. ��ᰡ ���� ��
 *      
 *  b. ��ᰡ ���� ��
 *  
 * 
 */