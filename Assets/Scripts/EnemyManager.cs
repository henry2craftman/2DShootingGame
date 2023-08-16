using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적을 생성한다.
// 필요 속성: 특정 시간, 현재 시간, 적 GameObject
// 순서1. 현재 시간이 흐른다.
// 순서2. 특정시간이 지나면
// 순서3. 적을 EnemyManager위치에 생성한다.
// 순서4. 시간을 초기화 해준다.
// 추가. 특정시간을 랜덤한 시간으로 설정한다.

// 목표: 에네미 오브젝트 풀을 만들어서 관리하고 싶다.
// 필요속성: 에네미 오브젝트의 개수, 오브젝트 풀 배열
// 순서1. 풀 사이즈 만큼의 배열을 생성한다.
// 순서2. 에네미 게임 오브젝트를 생성한다.
// 순서3. 생성한 에네미 게임 오브젝트를 풀에 넣는다.

// 목표: 에네미 게임오브젝트 풀에서 에네미 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
public class EnemyManager : MonoBehaviour
{
    // 필요 속성: 특정 시간, 현재 시간, 적 GameObject
    // 특정시간
    float createTime;

    //현재시간
    float currentTime = 0;

    //적 게임오브젝트
    public GameObject enemy;

    // 랜덤한 시간의 최소 최대값
    public float minTime = 3;
    public float maxTime = 5;

    // 필요속성: 에네미 오브젝트의 개수, 오브젝트 풀 배열
    public int poolSize = 10;
    List<GameObject> enemyObjectPool;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        // 목표: 에네미 오브젝트 풀을 만들어서 관리하고 싶다.
        // 순서1. 풀 사이즈 만큼의 배열을 생성한다.
        enemyObjectPool = new List<GameObject>();

        // 순서2. 에네미 게임 오브젝트를 생성한다.
        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemyGO = Instantiate(enemy);
            // 순서3. 생성한 에네미 게임 오브젝트를 풀에 넣는다.
            enemyObjectPool.Add(enemyGO);

            // 순서4. 게임오브젝트를 비활성화 해준다.
            enemyGO.SetActive(false);

            enemyGO.transform.parent = transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 순서1. 현재 시간이 흐른다.
        //currentTime = currentTime + Time.deltaTime;
        currentTime += Time.deltaTime;
        //print("currentTime: " + currentTime);

        // 순서2. 특정시간이 지나면
        if(currentTime > createTime)
        {
            // 순서3. 적을 EnemyManager위치에 생성한다.
            // 목표: 에네미 게임오브젝트 풀에서 에네미 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject enemyGO = enemyObjectPool[i];
            //    if(enemyGO.activeSelf == false)
            //    {
            //        enemyGO.SetActive(true);
            //        enemyGO.transform.position = gameObject.transform.position;
            //        break;
            //    }
            //}

            if(enemyObjectPool.Count > 0)
            {
                GameObject enemyGO = enemyObjectPool[0];

                enemyGO.SetActive(true);
                enemyGO.transform.position = gameObject.transform.position;
                
                enemyObjectPool.Remove(enemyGO);
            }

            // 순서4. 시간을 초기화 해준다.
            currentTime = 0;
        }
    }
}
