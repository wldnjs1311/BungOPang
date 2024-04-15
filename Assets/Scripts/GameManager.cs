using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Managers
    public TycoonManager tycoonManager;
    //public InputManager inputManager;

    //Game data
    public bool pause;
    public int income;
    public int[] lefts;

    public int[] selectedBung;

    //UI
    public GameObject pausePanel;
    public GameObject infoPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        income = 1000;
        lefts = new int[4];
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