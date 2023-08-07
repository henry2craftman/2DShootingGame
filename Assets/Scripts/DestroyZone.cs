using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적 또는 총알이 감지되었을 때, 그 물체를 파괴하고 싶다.
public class DestroyZone : MonoBehaviour
{
    // 충돌 직전
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            return;
        };

        Destroy(other.gameObject);
    }
}
