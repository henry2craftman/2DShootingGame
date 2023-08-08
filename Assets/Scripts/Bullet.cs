using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 내가(총알) 위로 날아간다.
// 방향이 필요하다.
// 속도가 필요하다.

// 목표2: 총을 쏜 주체가 플레이어인지 적인지 확인 후, 발사 방향을 정한다.
// 목표3: 충돌시 폭발 효과를 생성한다.
public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    // 목표: 내가(총알) 위로 날아간다.
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                player.GetComponent<PlayerMove>().hp--;

                if (player.GetComponent<PlayerMove>().hp < 0)
                {
                    // 부딪힌 상대를 파괴한다.
                    Destroy(otherObject.gameObject);
                }
            }
        }

        // 나를 파괴한다.
        Destroy(gameObject);

        // 목표3: 충돌시 폭발 효과를 생성한다.
        GameObject bulletExplosionGO = Instantiate(bulletExplosion);
        bulletExplosionGO.transform.position = transform.position;
    }
}
