using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TycoonManager tycoonManager;
    //public InputManager inputManager;

    public bool pause;
    public int income;

    public GameObject pausePanel;
    public GameObject infoPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        
    }

    public void GameOver()
    {
        pause = true;

        //�÷��� ��� panel ���
        //�÷��� ������ ����
    }

}

/*
 * �ʿ���
 * - ���� ����
 * - �÷��� Ÿ�� ���, ���� ǥ��
 * - �Ͻ�����
 * - ����� �Է� -> inputmanager ����
 * 
 */