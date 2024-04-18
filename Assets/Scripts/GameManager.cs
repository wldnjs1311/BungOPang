using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Managers
    public TycoonManager tycoonManager;
    //public InputManager inputManager;

    //Game data
    public bool pause;
    public int income = 0;
    public int[] ingreCnts = { 0, 0, 0, 0 };

    public int[] selectedBung;

    //UI
    public GameObject pausePanel;
    public GameObject infoPanel;
    public Text[] ingreTexts;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        for (int i = 0; i < ingreCnts.Length; i++)
        {
            ingreTexts[i].text = ingreCnts[i].ToString();
        }
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
    private void SaveIngre(int type, int amount)
    {
        ingreCnts[type] = (ingreCnts[type] + amount > 99) ? 99 : ingreCnts[type] + amount;
        ingreTexts[type].text = $"{ingreCnts}";
    }

    private void UseIngre(int type, int amount)
    {
        ingreCnts[type] = (ingreCnts[type] - amount < 0) ? 0 : ingreCnts[type] - amount;
        ingreTexts[type].text = $"{ingreCnts}";
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