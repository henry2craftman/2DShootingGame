using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 목표: 특정 시간에 한번씩 총알을 만들고 플레이어를 향해 발사한다.
// 필요속성: 총알, 현재시간, 특정시간, 플레이어, 플레이어방향
public class EnemyFire : MonoBehaviour
{
    // 필요속성: 총알, 현재시간, 특정시간, 플레이어, 플레이어방향
    public GameObject bullet;
    public GameObject gunPos;
    float currentTime;
    public float createTime = 1;
    GameObject player;
    Vector3 playerDir;

    // 필요속성: 총알 오브젝트의 개수, 오브젝트 풀 배열
    public int poolSize = 15;
    List<GameObject> bulletObjectPool;

    private void Start()
    {
        player = GameObject.Find("Player");

        // 순서1. 풀 사이즈 만큼의 배열을 생성한다.
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // 순서2. 총알 게임 오브젝트를 생성한다.
            GameObject bulletGO = Instantiate(bullet);

            // 순서3. 생성한 총알 게임 오브젝트를 풀에 넣는다.
            bulletObjectPool.Add(bulletGO);

            bulletGO.SetActive(false);
            bulletGO.transform.parent = transform;
            bullet.GetComponent<Bullet>().parentID = GetInstanceID();
        }

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
                // 목표: 총알 게임오브젝트 풀에서 총알 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
                //for (int i = 0; i < poolSize; i++)
                //{
                //    GameObject bullet = bulletObjectPool[i];

                //    // 풀에서 총알 게임오브젝트가 비활성화 되어있다면 
                //    if (bullet.activeSelf == false)
                //    {
                //        // 활성화 시키겠다.
                //        bullet.SetActive(true);

                //        // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                //        bullet.transform.position = gunPos.transform.position;
                //        bullet.GetComponent<Bullet>().dir = playerDir;    
                //        playerDir = (player.transform.position - gameObject.transform.position).normalized;

                //        break;
                //    }
                //}
                if (bulletObjectPool.Count > 0)
                {
                    GameObject bullet = bulletObjectPool[0];
                    bullet.SetActive(true);
                    bullet.transform.position = transform.position;

                    bullet.GetComponent<Bullet>().dir = playerDir;
                    playerDir = (player.transform.position - gameObject.transform.position).normalized;

                    bulletObjectPool.Remove(bullet);
                }

                currentTime = 0;
            }
        }
    }
}
