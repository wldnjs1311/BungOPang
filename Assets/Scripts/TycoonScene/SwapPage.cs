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

    public float swapDistance = 100f; //swap ��ų �ּ� �Ÿ�

    

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


//����� �Է¸� ��Ƴ��� inputManager ����� �Լ� ȣ���ϴ� ������� �����ؾ� ��
