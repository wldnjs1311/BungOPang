using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���
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
        //���� �Ŵ������� ����� �ؾ ��������Ʈ ��������
    }

    void Update()
    {
        
    }
}
