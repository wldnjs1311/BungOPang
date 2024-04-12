using UnityEngine;

public class Timer : MonoBehaviour
{
    private GameManager gameManager;

    private float endTime = 180f;
    private float curTime = 0f;
    public GameObject timeBar;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        //Ÿ�̸� ������Ʈ
        if (!gameManager.pause)
        {
            curTime += Time.deltaTime;
            UpdateClock();
        }

        //�ð� �ʰ�
        if(curTime >= endTime) gameManager.GameOver();
    }
    
    private void UpdateClock()
    {
        float x_scale = (endTime - curTime)/endTime;
        timeBar.transform.localScale = new Vector3(x_scale, 1f, 1f);
    }
}
