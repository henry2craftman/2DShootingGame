using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 목표: 스킬아이템을 특정시간 마다 만든다.
// 필요속성: 스킬아이템, 특정시간, 현재시간
// 단계1. 시간이 흐른다.
// 단계2. 현재 시간이 특정 랜덤 시간(최소시간, 최대시간)을 넘으면
// 단계3. 스킬아이템을 생성한다.
// 단계4. 스킬 위치를 스킬매니저의 위치로 설정한다.
// 단계5. 시간을 다시 설정해준다.
public class SkillManager : MonoBehaviour
{
    // 필요속성: 스킬아이템, 특정시간, 현재시간
    public GameObject skillItem;
    float createTime;
    public float minCreateTime = 3;
    public float maxCreateTime = 10;
    float currentTime;

    private void Start()
    {
        createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 목표: 스킬아이템을 특정시간 마다 만든다.
        // 단계1. 시간이 흐른다.
        currentTime += Time.deltaTime;

        // 단계2. 현재 시간이 특정시간을 넘으면
        if(currentTime > createTime)
        {
            // 단계3. 스킬아이템을 생성한다.
            GameObject skillItemGO = Instantiate(skillItem);

            // 단계4. 스킬 위치를 스킬매니저의 위치로 설정한다.
            skillItemGO.transform.position = transform.position;

            currentTime = 0;

            // 단계5. 시간을 다시 설정해준다.
            createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);
        }
    }
}
