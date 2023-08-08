using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 이펙트의 파티클 효과가 종료되면 내 스스로를 파괴한다.
// 속성: 파티클시스템
public class Effect : MonoBehaviour
{
    // 속성: 파티클시스템
    ParticleSystem rootParticleSystem;

    private void Start()
    {
        rootParticleSystem = this.GetComponentInChildren<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Update()
    {
        // 목표: 이펙트의 파티클 효과가 종료되면 내 스스로를 파괴한다.
        if (!rootParticleSystem.IsAlive(true))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
