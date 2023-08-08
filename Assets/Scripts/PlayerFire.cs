using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 사용자 입력(Space)를 받아 총알을 만들고 싶다.
// 순서1: 입력을 받고 싶다.
// 순서2: 총알을 만들고 싶다.

// 목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
// 속성: 스킬레벨
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;

    // Update is called once per frame
    void Update()
    {
        // 순서1: 입력을 받고 싶다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch(_skillLevel)
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
        }

        // 한개의 총알이 발사된다.
        void ExcuteSkill0()
        {
            // 순서2: 총알을 만들고 싶다.
            GameObject bulletGO = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bulletGO.transform.position = gunPos.transform.position;
        }

        // 두개의 총알이 발사된다.
        void ExcuteSkill1()
        {
            // 순서2: 총알을 만들고 싶다.
            GameObject bulletGO = Instantiate(bullet);
            GameObject bulletGO1 = Instantiate(bullet);

            // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
            bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f , 0, 0);
            bulletGO1.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            skillLevel++;
        }
    }
}
