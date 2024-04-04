using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour
{
    float maxTemperature_ = 10f;
    float temperature_ = 0f;
    float risingStep_ = 3f;
    float decreaseSpeed_ = 1f;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            temperature_ = (temperature_ + risingStep_ > maxTemperature_) ? maxTemperature_ : temperature_ + risingStep_;
            //애니메이션
        }

        float decrease = decreaseSpeed_ * Time.deltaTime;
        temperature_ = (temperature_ < decrease) ? 0 : temperature_ - decrease;

        SwapSprite();
    }

    void SwapSprite()
    {

    }
}
