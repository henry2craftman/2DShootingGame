using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 목표: 특정 시간에 한번씩 총알을 만들고 플레이어를 향해 발사한다.
// 필요속성: 총알, 현재시간, 특정시간, 플레이어, 플레이어방향
public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    float currentTime;
    public float createTime = 1;
    GameObject player;
    Vector3 playerDir;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            currentTime += Time.deltaTime;

            if (currentTime > createTime)
            {
                // 순서2: 총알을 만들고 싶다.
                GameObject bulletGO = Instantiate(bullet);
                bulletGO.tag = "EnemyBullet";

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = gunPos.transform.position;

                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                bulletGO.GetComponent<Bullet>().dir = playerDir;

                currentTime = 0;
            }
        }
    }
}
