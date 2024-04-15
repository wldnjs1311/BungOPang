using JetBrains.Annotations;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //GameManager한테 받아올 정보
    private GameManager gameManager;
    private int id; //진열할 붕어빵
    private int maxSize = 10; //진열 최대치
    public Sprite sprite;

    private int stockSize = 5; //현재 재고
    private float xRange = 3f;

    private GameObject[] bungOs; //붕어빵 오브젝트

    private void Start()
    {
        gameManager = GameManager.instance;
        bungOs = new GameObject[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            //자식
            bungOs[i] = new GameObject($"Bung{id}_{i}");

            float xPos = (xRange / maxSize) * i - xRange / 2;
            bungOs[i].transform.parent = gameObject.transform;
            bungOs[i].transform.position = new Vector3(xPos, transform.position.y, 0);

            var spren = bungOs[i].AddComponent<SpriteRenderer>();
            spren.sprite = sprite;
            spren.sortingOrder = i + 2;

            bungOs[i].SetActive(false);
        }
    }

    public void Sell(int amount)
    {
        //재고 다른 manager에서 확인하기
        if (stockSize < amount) Debug.Log("붕어빵이 부족합니다.");
        else
        {
            int end = stockSize - amount;
            for(; stockSize > end; stockSize--)
            {
                bungOs[stockSize].SetActive(false);
            }

        }
    }

    public void Save(int amount)
    {
        int origin = stockSize;

        if(stockSize + amount >maxSize) stockSize = maxSize;
        else
            stockSize = stockSize + amount;
        
        for(;origin < stockSize; origin++)
            bungOs[origin].SetActive(true);
    }
}

//선택된 붕어빵으로 data 정리