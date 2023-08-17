using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 사용자 입력(Space)를 받아 총알을 만들고 싶다.
// 순서1: 입력을 받고 싶다.
// 순서2: 총알을 만들고 싶다.

// 목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
// 속성: 스킬레벨
// 단계1. 아이템을 먹었다면
// 단계2. 스킬레벨이 1 올라간다.
// 단계3. 아이템을 파괴한다.
// 단계4. 아이템 이펙트를 생성한다.
// 단계5. 발사시 SoundManger의 AudioSource를 재생한다.
// 속성: SoundManager.instance

// 목표3: 총알 오브젝트 풀을 만들어서 관리하고 싶다.
// 필요속성: 총알 오브젝트의 개수, 오브젝트 풀 배열
// 순서1. 풀 사이즈 만큼의 배열을 생성한다.
// 순서2. 총알 게임 오브젝트를 생성한다.
// 순서3. 생성한 총알 게임 오브젝트를 풀에 넣는다.

// 목표: 총알 게임오브젝트 풀에서 총알 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;
    public int degree = 15;

    // 필요속성: 총알 오브젝트의 개수, 오브젝트 풀 배열
    public int poolSize = 100;
    //GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;

    private void Start()
    {
        // 순서1. 풀 사이즈 만큼의 배열을 생성한다.
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // 순서2. 총알 게임 오브젝트를 생성한다.
            GameObject bulletGO = Instantiate(bullet);

            // 순서3. 생성한 총알 게임 오브젝트를 풀에 넣는다.
            //bulletObjectPool[i] = bulletGO;
            bulletObjectPool.Add(bulletGO);

            bulletGO.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // 순서1: 입력을 받고 싶다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill();
        }
#endif
    }

    public void ExcuteSkill()
    {
        switch (skillLevel)
        {
            case 0:
                ExcuteSkill0();
                break;
            case 1:
                ExcuteSkill1();
                break;
            case 2:
                ExcuteSkill2();
                break;
            case 3:
                ExcuteSkill3(degree);
                break;
        }

        // 단계5. 발사시 SoundManger의 AudioSource를 재생한다.
        SoundManager.instance.effAudioSource.clip = SoundManager.instance.fireAudioClips[0];
        SoundManager.instance.effAudioSource.Play();

        // 한개의 총알이 발사된다.
        void ExcuteSkill0()
        {
            // 순서2: 총알을 만들고 싶다.
            // 목표: 총알 게임오브젝트 풀에서 총알 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
            /*for (int i = 0; i < poolSize; i++)
            {
                GameObject bulletGO = bulletObjectPool[i];

                // 풀에서 총알 게임오브젝트가 비활성화 되어있다면 
                if (bulletGO.activeSelf == false)
                {
                    // 활성화 시키겠다.
                    bulletGO.SetActive(true);

                    // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                    bulletGO.transform.position = gunPos.transform.position;

                    break;
                }
            }*/
            if (bulletObjectPool.Count > 0)
            {
                GameObject bulletGO = bulletObjectPool[0];

                // 활성화 시키겠다.
                bulletGO.SetActive(true);

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = gunPos.transform.position;

                bulletObjectPool.Remove(bulletGO);
            }
        }

        // 두개의 총알이 발사된다.
        void ExcuteSkill1()
        {
            // 순서2: 총알을 만들고 싶다.
            // 목표: 총알 게임오브젝트 풀에서 총알 게임오브젝트가 비활성화 되어있다면 활성화 시키겠다.
            /*for (int i = 0; i < poolSize; i++)
            {
                GameObject bulletGO = bulletObjectPool[i];

                // 풀에서 총알 게임오브젝트가 비활성화 되어있다면 
                if (bulletGO.activeSelf == false)
                {
                    // 활성화 시키겠다.
                    bulletGO.SetActive(true);

                    // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                    bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);

                    break;
                }
            }

            for (int i = 0; i < poolSize; i++)
            {
                GameObject bulletGO1 = bulletObjectPool[i];

                // 풀에서 총알 게임오브젝트가 비활성화 되어있다면 
                if (bulletGO1.activeSelf == false)
                {
                    // 활성화 시키겠다.
                    bulletGO1.SetActive(true);

                    // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                    bulletGO1.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);

                    break;
                }
            }*/

            if (bulletObjectPool.Count > 0)
            {
                GameObject bulletGO = bulletObjectPool[0];

                // 활성화 시키겠다.
                bulletGO.SetActive(true);

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);

                bulletObjectPool.Remove(bulletGO);
            }

            if (bulletObjectPool.Count > 0)
            {
                GameObject bulletGO = bulletObjectPool[0];

                // 활성화 시키겠다.
                bulletGO.SetActive(true);

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);

                bulletObjectPool.Remove(bulletGO);
            }
        }

        // 세개의 총알이 발사된다.
        // 1, 2, 3 총알 중 1, 3 총알이 각각 Z축으로 -30도, 30도 회전 후 발사된다.
        void ExcuteSkill2()
        {
            // 순서2: 총알을 만들고 싶다.
            GameObject bulletGO = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bulletGO.transform.position = gunPos.transform.position;

            // 순서2: 총알을 만들고 싶다.
            GameObject bulletGO2 = Instantiate(bullet);
            GameObject bulletGO3 = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bulletGO2.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO2.transform.rotation = Quaternion.Euler(0, 0, 30);
            bulletGO2.GetComponent<Bullet>().dir = bulletGO2.transform.up;


            bulletGO3.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
            bulletGO3.transform.rotation = Quaternion.Euler(0, 0, -30);
            bulletGO3.GetComponent<Bullet>().dir = bulletGO3.transform.up;
        }


        // 15도 간격마다 총 24개의 총알을 360도 발사한다.
        void ExcuteSkill3(int _degree)
        {
            int numOfBullet = 360 / degree;

            for (int i = 0; i < numOfBullet; i++)
            {
                // 순서2: 총알을 만들고 싶다.
                GameObject bulletGO = Instantiate(bullet);

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = gunPos.transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
                bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;
            }
        }
    }

    // 목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
    private void OnTriggerEnter(Collider other)
    {
        // 단계1. 아이템을 먹었다면
        if (other.gameObject.tag == "Item")
        {
            // 단계2. 스킬레벨이 1 올라간다.(최대 스킬레벨을 초과하기 전까지)
            if(skillLevel < 3)
                skillLevel++;

            // 단계3. 아이템을 파괴한다.
            other.gameObject.SetActive(false);
        }
    }
}
