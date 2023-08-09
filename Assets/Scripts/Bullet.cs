using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ����(�Ѿ�) ���� ���ư���.
// ������ �ʿ��ϴ�.
// �ӵ��� �ʿ��ϴ�.

// ��ǥ2: ���� �� ��ü�� �÷��̾����� ������ Ȯ�� ��, �߻� ������ ���Ѵ�.
// ��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
// ��ǥ4: �÷��̾� �ı��� �ְ� ������ BestScoreUI�� ������ ������Ʈ���� �����Ѵ�.
public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    // ��ǥ: ����(�Ѿ�) ���� ���ư���.
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
                    // �ε��� ��븦 �ı��Ѵ�.
                    Destroy(otherObject.gameObject);

                    // ��ǥ10: �÷��̾� �ı��� �ְ� ������ BestScoreUI�� ������ ������Ʈ���� �����Ѵ�.
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                    gameManager.bestScore = gameManager.attackScore + gameManager.destroyScore;
                    gameManager.bestScoreTxt.text = gameManager.bestScore.ToString();

                    PlayerPrefs.SetInt("Best Score", gameManager.bestScore);
                }
            }
        }

        // ���� �ı��Ѵ�.
        Destroy(gameObject);

        // ��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
        GameObject bulletExplosionGO = Instantiate(bulletExplosion);
        bulletExplosionGO.transform.position = transform.position;
    }
}
