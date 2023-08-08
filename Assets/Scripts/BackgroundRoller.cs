using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: Background의 Material의 Offset의 Y를 일정속도로 변화시키고 싶다.
// 속성: 현재시간, 속도, 매터리얼
public class BackgroundRoller : MonoBehaviour
{
    // 속성: 현재시간, 속도
    float currentTime;
    public float speed = 1;
    public Material material;

    // Update is called once per frame
    void Update()
    {
        currentTime += speed * Time.deltaTime;

        material.mainTextureOffset = Vector3.up  * currentTime;

    }
}
