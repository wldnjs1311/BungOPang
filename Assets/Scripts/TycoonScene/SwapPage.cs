using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapPage : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 dragStartPosition;

    private Transform myTransform;
    private Transform leftBoarder;
    private Transform rightBoarder;

    public float swapDistance = 100f; //swap 시킬 최소 거리

    

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        rightBoarder = GetComponent<Transform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }




}


//사용자 입력만 모아놓은 inputManager 만들고 함수 호출하는 방식으로 변경해야 함
