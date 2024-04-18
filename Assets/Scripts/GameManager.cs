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

        //�÷��� ��� panel ���
        //�÷��� ������ ����
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
 * �ʿ���
 * - ���� ����
 * - �÷��� Ÿ�� ���, ���� ǥ��
 * - �Ͻ�����
 * - ����� �Է� -> inputmanager ����
 * 
 */