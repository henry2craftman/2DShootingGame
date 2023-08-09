using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 스킬아이템이 아래 방향으로 특정속도로 이동한다.
// 속성: 아래 방향, 특정속도
public class SkillItemMove : MonoBehaviour
{
    // 속성: 아래 방향, 특정속도
    Vector3 dir = Vector3.down;
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        // 목표: 스킬아이템이 아래 방향으로 특정속도로 이동한다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
