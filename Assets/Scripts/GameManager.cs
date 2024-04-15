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

        //플레이 요약 panel 출력
        //플레이 데이터 저장
    }

}

/*
 * 필요기능
 * - 점수 저장
 * - 플레이 타임 계산, 수익 표시
 * - 일시정지
 * - 사용자 입력 -> inputmanager 연결
 * 
 */