using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Mold : MonoBehaviour
{
    public Sprite[] sprite_;

    private int id_ = 0; // 사용된 재료, 어떤 붕어빵인지 결정
    private int state_ = 0;
    public float cookingDegree_ = 0; // 익은 정도
    private float speed_ = 5;

    private SpriteRenderer bung_;
    private Animator anim_;


    void Awake()
    {
        bung_ = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim_ = GetComponent<Animator>();
    }

    void Update() //나중에 업데이트 말고 gamemanager에서 playing일 때 호출되게
    {
        Cooking();
    }

    private void OnMouseDown()
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
            SetBungOPangID(3);
        }
    }
    void SetBungOPangID(int id)
    {
        id_ = id;
    }

    void Flip()
    {
        if (anim_.GetBool("Flip"))
            anim_.SetBool("Flip", false);
        else 
            anim_.SetBool("Flip", true);
    }

    void GetBungOPang()
    {
        //전달

        //초기화
        id_ = 0;
        state_ = 0;
        cookingDegree_ = 0;
        bung_.sprite = sprite_[0];
        //이미지 초기화
    }

    void Cooking()
    {
        if (id_ == 0) return; //아무것도 안굽고 있으면 return

        //굽고 있으면 cooking 업데이트
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
            bung_.sprite = sprite_[2];
        }
        else
        {
            bung_.sprite = sprite_[1];
        }
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