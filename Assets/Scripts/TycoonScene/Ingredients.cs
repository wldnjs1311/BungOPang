using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    int id_ = 0;
    int size_ = 10;
    Sprite sprite_;
    GameObject prefab_;

    void Awake()
    {
        prefab_ = GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(size_ > 0)
            {
                GameObject ingre = Instantiate<GameObject>(prefab_);

            }
            else
            {
                Debug.Log("Empty!");
            }

        }
    }
    
    public void Use()
    {
        size_--;
    }
}
