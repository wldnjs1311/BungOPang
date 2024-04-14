using Unity.VisualScripting;
using UnityEngine;

public class Mold : MonoBehaviour
{
    public Sprite[] sprite_;

    private int id_ = 0; // 굽고있는 붕어빵 종류
    private bool isEmpty = true;
    private float cookingDegree_ = 0; // 익은 정도
    private float speed_ = 5;

    private bool flip = false;
    private bool alflip = false;
    private int flipCount = 0; //flip 횟수에 따라 붕어빵 퀄리티 다름

    private SpriteRenderer bung_;
    private Animation anim_;


    void Awake()
    {
        bung_ = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim_ = GetComponent<Animation>();
    }

    void Update() //나중에 업데이트 말고 gamemanager에서 playing일 때 호출되게
    {
        Cooking();
    }

    private void OnMouseDown()
    {
        if (isEmpty)
        {
            SetBungOPangID(0);//임시 test 코드, 붕어빵 넣기
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
        //보관


        //초기화
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

        //굽고 있으면 cooking 업데이트
        cookingDegree_ += speed_ * Time.deltaTime;

        //0~3 : 공통, 4~6 : 장착 붕어빵
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
            //id 설정, 현재 들고 있는 붕어 재료로
            SetBungOPangID(1);
            //재료 수 줄이기
        }
    }
}

/*
 * 몰드가 해야 할 역할
 * 1. 플레이어 입력 처리
 *  a. 재료 넣기
 *  b. 뒤집기
 *  c. 완성시키기
 *  
 * 2. 시간과 열에 따른 굽기
 *  a. 재료가 있을 때
 *      
 *  b. 재료가 없을 때
 *  
 * 
 */