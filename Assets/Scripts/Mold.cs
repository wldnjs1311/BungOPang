using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mold : MonoBehaviour
{
    [SerializeField]
    int id_ = 0; // 사용된 재료, 어떤 붕어빵인지 결정
    float state_ = 0; // 0 - 100 익은 정도
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
