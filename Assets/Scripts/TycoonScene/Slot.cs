using JetBrains.Annotations;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //GameManager���� �޾ƿ� ����
    private GameManager gameManager;
    private int id; //������ �ؾ
    private int maxSize = 10; //���� �ִ�ġ
    public Sprite sprite;

    private int stockSize = 5; //���� ���
    private float xRange = 3f;

    private GameObject[] bungOs; //�ؾ ������Ʈ

    private void Start()
    {
        gameManager = GameManager.instance;
        bungOs = new GameObject[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            //�ڽ�
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
        //��� �ٸ� manager���� Ȯ���ϱ�
        if (stockSize < amount) Debug.Log("�ؾ�� �����մϴ�.");
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

//���õ� �ؾ���� data ����