using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//재료
enum Ingredient
{
    Dough,
    
}
public class TycoonManager : MonoBehaviour
{

    int[] ingreSize_ = { 0, 0, 0, 0, 0 };


    GameObject cookingPan_;
    GameObject[] molds_;


    Sprite[] bungSprites_;
    
    
    void Awake()
    {
        //molds_ = cookingPan_.GetComponentsInChildren<GameObject>();
        //게임 매니저에서 사용할 붕어빵 스프라이트 가져오기
    }

    void Update()
    {
        
    }
}
