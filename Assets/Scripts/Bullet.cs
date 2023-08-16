using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 내가(총알) 위로 날아간다.
// 필요속성: 방향, 속도
// 목표2: 총을 쏜 주체가 플레이어인지 적인지 확인 후, 발사 방향을 정한다.
// 목표3: 충돌시 폭발 효과를 생성한다.
// 필요속성: 폭발효과
// 목표4: 플레이어 파괴시 최고 점수를 BestScoreUI와 플팻폼 레지스트리에 저장한다.
// 목표5: 피격시 피격 soundEff를 실행한다.
// 필요속성: 사운드매니저
public class Bullet : MonoBehaviour
{
    // 필요속성: 방향, 속도
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;
    public int parentID;


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
                    // 부딪힌 상대를 파괴(비활성화)한다.
                    otherObject.gameObject.SetActive(false);

                    // 목표10: 플레이어 파괴시 최고 점수를 BestScoreUI와 플팻폼 레지스트리에 저장한다.
                    GameManager.instance.SetBestScore();

                    // 목표5: 피격시 피격 soundEff를 실행한다.
                    SoundManager.instance.effAudioSource.clip = SoundManager.instance.explosionAudioClips[1];
                    SoundManager.instance.effAudioSource.Play();
                }
            }
        }

        // 나를 파괴(비활성화)한다.
        gameObject.SetActive(false);    

        // 목표3: 충돌시 폭발 효과를 생성한다.
        GameObject bulletExplosionGO = Instantiate(bulletExplosion);
        bulletExplosionGO.transform.position = transform.position;

        SoundManager.instance.effAudioSource.clip = SoundManager.instance.explosionAudioClips[2];
        SoundManager.instance.effAudioSource.Play();
    }
}
