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

// 목표: 아이템 오브젝트 풀을 만들어서 관리하고 싶다.
// 필요속성: 아이템 오브젝트의 개수, 오브젝트 풀 배열
// 순서1. 풀 사이즈 만큼의 배열을 생성한다.
// 순서2. 아이템 게임 오브젝트를 생성한다.
// 순서3. 생성한 아이템 게임 오브젝트를 풀에 넣는다.
// 순서4: 아이템을 자식으로 설정해준다.

// 목표: 아이템 게임오브젝트 풀에서 아이템 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    // 필요속성: 스킬아이템, 특정시간, 현재시간
    public GameObject skillItem;
    float createTime;
    public float minCreateTime = 3;
    public float maxCreateTime = 10;
    float currentTime;

    // 필요속성: 아이템 오브젝트의 개수, 오브젝트 풀 배열
    public int poolSize = 10;
    public List<GameObject> itemObjectPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);

        // 순서1. 풀 사이즈 만큼의 배열을 생성한다.
        itemObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // 순서2. 아이템 게임 오브젝트를 생성한다.
            GameObject skillItemGO = Instantiate(skillItem);

            // 순서3. 생성한 아이템 게임 오브젝트를 풀에 넣는다.
            itemObjectPool.Add(skillItemGO);

            skillItemGO.gameObject.SetActive(false);

            // 순서4: 아이템을 자식으로 설정해준다.
            skillItemGO.transform.parent = transform;
        }
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
            // 목표: 에네미 게임오브젝트 풀에서 에네미 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject itemGO = itemObjectPool[i];
            //    if(itemGO.activeSelf == false)
            //    {
            //        itemGO.SetActive(true);

            //        // 단계4. 스킬 위치를 스킬매니저의 위치로 설정한다.
            //        itemGO.transform.position = transform.position;
            //    }
            //}

            if(itemObjectPool.Count > 0)
            {
                GameObject itemGO = itemObjectPool[0];

                itemGO.SetActive(true);

                // 단계4. 스킬 위치를 스킬매니저의 위치로 설정한다.
                itemGO.transform.position = transform.position;

                itemObjectPool.Remove(itemGO);
            }

            currentTime = 0;

            // 단계5. 시간을 다시 설정해준다.
            createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);
        }
    }
}
