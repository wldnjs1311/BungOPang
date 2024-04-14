using Unity.VisualScripting;
using UnityEngine;

public class Mold : MonoBehaviour
{
    public Sprite[] sprite_;

    private int id_ = 0; // �����ִ� �ؾ ����
    private bool isEmpty = true;
    private float cookingDegree_ = 0; // ���� ����
    private float speed_ = 5;

    private bool flip = false;
    private bool alflip = false;
    private int flipCount = 0; //flip Ƚ���� ���� �ؾ ����Ƽ �ٸ�

    private SpriteRenderer bung_;
    private Animation anim_;


    void Awake()
    {
        bung_ = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim_ = GetComponent<Animation>();
    }

    void Update() //���߿� ������Ʈ ���� gamemanager���� playing�� �� ȣ��ǰ�
    {
        Cooking();
    }

    private void OnMouseDown()
    {
        if (isEmpty)
        {
            SetBungOPangID(0);//�ӽ� test �ڵ�, �ؾ �ֱ�
            isEmpty = false;
        }
        else
        {
            if (cookingDegree_ > 150)
            {
                GetBungOPang();
            }
            else if (cookingDegree_ > 50 && !alflip)
            {
                Flip();
            }
        }
    }

    void SetBungOPangID(int id)
    {
        id_ = id;
    }

    void GetBungOPang()
    {
        //����


        //�ʱ�ȭ
        id_ = 0;
        isEmpty = true;
        cookingDegree_ = 0;
        flipCount = 0;
        bung_.sprite = null;
    }

    void Flip()
    {
        if (flip)
        {
            anim_.Play("MoldFlipReturn");
            flip = false;
        }
        else
        {
            anim_.Play("MoldFlipX");
            flip = true;
        }

        alflip = true;
        flipCount++;
    }



    void Cooking()
    {
        if (isEmpty) return;

        //���� ������ cooking ������Ʈ
        cookingDegree_ += speed_ * Time.deltaTime;

        //0~3 : ����, 4~6 : ���� �ؾ
        if (cookingDegree_ > 250)
            bung_.sprite = sprite_[3];
        else if (cookingDegree_ > 150)
            bung_.sprite = sprite_[4 + id_];
        else if (cookingDegree_ > 100)
        {
            bung_.sprite = sprite_[2];
        }
        else if(cookingDegree_ > 50)
        {
            bung_.sprite = sprite_[1];
        }
        else
            bung_.sprite = sprite_[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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