using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 아래 방향으로 이동한다.

// 목표2: 다른 충돌체와 부딪혔으면 나, 상대를 파괴한다.

// 목표3: 시작시 30%의 확률로 플레이어를 따라간다.
// 필요속성: 30%의 확률

// 목표4: 10프로의 확률로 플레이어를 따라간다.
// 필요속성: 플레이어의 방향

// 목표5: 적도 플레이어를 향해 특정 시간에 한번씩 총을 쏜다.
// 필요속성: 총알, 특정 시간

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.down;
    int randValue;
    GameObject player;

    // 필요속성: 플레이어의 방향
    Vector3 playerDir;

    private void Start()
    {
        // 필요속성: 30%의 확률
        randValue = Random.Range(0, 10); // 0 ~ 9 사이의 임의 값
        player = GameObject.Find("Player");

        if (randValue < 5)
        {
            if (player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
                //dir.Normalize();
            }
        }
    }

    // 목표: 아래 방향으로 이동한다.
    void Update()
    {
        // 목표4: 10프로의 확률로 플레이어를 따라간다.
        if (randValue < 3)
        {
            if(player != null) 
            {
                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                dir = playerDir;
            }
            
        }

        transform.position += dir * speed * Time.deltaTime;
    }

    // 목표2: 다른 충돌체와 부딪혔으면 나, 상대를 파괴한다.
    // 충돌 순간 실행
    private void OnCollisionEnter(Collision otherObject)
    {
        // 나를 파괴한다.
        Destroy(gameObject);

        // 부딪힌 상대를 파괴한다.
        Destroy(otherObject.gameObject);
    }

    // 충돌 중 실행
    private void OnCollisionStay(Collision collision)
    {
    }

    // 충돌 종료시 실행
    private void OnCollisionExit(Collision collision)
    {  
    }
}
