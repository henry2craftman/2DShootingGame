using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 플레이어를 사용자 입력에 따라 움직이고 싶다.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public int hp = 100;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.up * v;

        //transform.Translate(dir * speed * Time.deltaTime);
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        GameManager.instance.GameOver();
    }
}
