using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private GameManager gameManager;

    public Text text;


    void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        text.text = (string.Format("{0:#,###}", gameManager.income)).ToString();
    }
}
