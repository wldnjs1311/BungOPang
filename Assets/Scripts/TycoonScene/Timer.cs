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
        //타이머 업데이트
        if (!gameManager.pause)
        {
            curTime += Time.deltaTime;
            UpdateClock();
        }

        //시간 초과
        if(curTime >= endTime) gameManager.GameOver();
    }
    
    private void UpdateClock()
    {
        float x_scale = (endTime - curTime)/endTime;
        timeBar.transform.localScale = new Vector3(x_scale, 1f, 1f);
    }
}
