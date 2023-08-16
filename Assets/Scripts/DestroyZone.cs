using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적 또는 총알이 감지되었을 때, 그 물체를 파괴하고(비활성화) 싶다.
// 목표2: 총알이 비활성화 되면 플레이어의 자식으로 설정해준다.
public class DestroyZone : MonoBehaviour
{
    // 충돌 직전
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            return;
        };


        // 목표2: 총알이 비활성화 되면 플레이어의 자식으로 설정해준다.
        if (other.gameObject.tag == "PlayerBullet")
        {
            // 목표: 적 또는 총알이 감지되었을 때, 그 물체를 파괴하고(비활성화) 싶다.
            other.gameObject.SetActive(false);
            other.transform.parent = GameManager.instance.player.transform;
        }

        if (other.gameObject.tag == "Item")
        {
            // 목표: 적 또는 총알이 감지되었을 때, 그 물체를 파괴하고(비활성화) 싶다.
            other.gameObject.SetActive(false);
            other.transform.parent = SkillManager.instance.transform;
        }
    }
}
