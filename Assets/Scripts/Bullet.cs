using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ����(�Ѿ�) ���� ���ư���.
// �ʿ�Ӽ�: ����, �ӵ�
// ��ǥ2: ���� �� ��ü�� �÷��̾����� ������ Ȯ�� ��, �߻� ������ ���Ѵ�.
// ��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
// �ʿ�Ӽ�: ����ȿ��
// ��ǥ4: �÷��̾� �ı��� �ְ� ������ BestScoreUI�� ������ ������Ʈ���� �����Ѵ�.
// ��ǥ5: �ǰݽ� �ǰ� soundEff�� �����Ѵ�.
// �ʿ�Ӽ�: ����Ŵ���
public class Bullet : MonoBehaviour
{
    // �ʿ�Ӽ�: ����, �ӵ�
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    // �ʿ�Ӽ�: ����Ŵ���
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

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

                    // ��ǥ5: �ǰݽ� �ǰ� soundEff�� �����Ѵ�.
                    soundManager.effAudioSource.clip = soundManager.explosionAudioClips[1];
                    soundManager.effAudioSource.Play();
                }
            }
        }

        // ���� �ı��Ѵ�.
        Destroy(gameObject);

        // ��ǥ3: �浹�� ���� ȿ���� �����Ѵ�.
        GameObject bulletExplosionGO = Instantiate(bulletExplosion);
        bulletExplosionGO.transform.position = transform.position;

        soundManager.effAudioSource.clip = soundManager.explosionAudioClips[2];
        soundManager.effAudioSource.Play();
    }
}
