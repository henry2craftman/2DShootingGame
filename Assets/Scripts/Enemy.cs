using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: �Ʒ� �������� �̵��Ѵ�.

// ��ǥ2: �ٸ� �浹ü�� �ε������� ��, ��븦 �ı��Ѵ�.

// ��ǥ3: ���۽� 30%�� Ȯ���� �÷��̾ ���󰣴�.
// �ʿ�Ӽ�: 30%�� Ȯ��

// ��ǥ4: 10������ Ȯ���� �÷��̾ ���󰣴�.
// �ʿ�Ӽ�: �÷��̾��� ����

// ��ǥ5: ���� �÷��̾ ���� Ư�� �ð��� �ѹ��� ���� ���.
// �ʿ�Ӽ�: �Ѿ�, Ư�� �ð�

// ��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
// �ʿ�Ӽ�: ����ȿ�� ���ӿ�����Ʈ

// ��ǥ7: �浹�� hp�� �����Ѵ�.
// �ʿ�Ӽ�: hp

// ��ǥ8: �ǰݽ� ���Ӹ޴����� attackScore�� 10�÷��ش�.
// ����1. ���۽� ���ӸŴ����� �ҷ��´�.
// �ʿ�Ӽ�: ���ӸŴ���
// ��ǥ9: �ǰݽ� ���Ӹ޴����� destroyScore�� 100�÷��ش�.
// ��ǥ10: �÷��̾� �ı��� �ְ� ������ ������ ������Ʈ���� �����Ѵ�.
public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.down;
    int randValue;
    GameObject player;


    // �ʿ�Ӽ�: �÷��̾��� ����
    Vector3 playerDir;

    // �ʿ�Ӽ�: ����ȿ�� ���ӿ�����Ʈ
    public GameObject explosionEff;

    // �ʿ�Ӽ�: hp
    int hp = 3;

    // �ʿ�Ӽ�: ���ӸŴ���
    GameManager gameManager;

    private void Start()
    {
        // �ʿ�Ӽ�: 30%�� Ȯ��
        randValue = Random.Range(0, 10); // 0 ~ 9 ������ ���� ��
        player = GameObject.Find("Player");

        if (randValue < 5)
        {
            if (player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
                //dir.Normalize();
            }
        }

        // ����1. ���۽� ���ӸŴ����� �ҷ��´�.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // ��ǥ: �Ʒ� �������� �̵��Ѵ�.
    void Update()
    {
        // ��ǥ4: 10������ Ȯ���� �÷��̾ ���󰣴�.
        if (randValue < 3)
        {
            if(player != null) 
            {
                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                dir = playerDir;
            }
            
        }

        transform.position += dir * speed * Time.deltaTime;
    }

    // ��ǥ2: �ٸ� �浹ü�� �ε������� ��, ��븦 �ı��Ѵ�.
    // �浹 ���� ����
    private void OnCollisionEnter(Collision otherObject)
    {
        hp--;
        // ��ǥ8: �ǰݽ� ���Ӹ޴����� attackScore�� 10�÷��ش�.
        gameManager.attackScore += 10;
        gameManager.attackScoreTxt.text = gameManager.attackScore.ToString();

        if (otherObject.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMove>().hp--;

            if (player.GetComponent<PlayerMove>().hp < 0)
            {
                // �ε��� ��븦 �ı��Ѵ�.
                Destroy(otherObject.gameObject);

                gameManager.bestScore = gameManager.attackScore + gameManager.destroyScore;
                gameManager.bestScoreTxt.text = gameManager.bestScore.ToString();

                // ��ǥ10: �÷��̾� �ı��� �ְ� ������ ������ ������Ʈ���� �����Ѵ�.
                PlayerPrefs.SetInt("Best Score", gameManager.bestScore);
            }

            // ���� �ı��Ѵ�.
            Destroy(gameObject);

            // ��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
            GameObject explosionGO = Instantiate(explosionEff);
            explosionGO.transform.position = gameObject.transform.position;

            // ��ǥ9: �ǰݽ� ���Ӹ޴����� destroyScore�� 100�÷��ش�.
            gameManager.destroyScore += 100;
            gameManager.destroyScoreTxt.text = gameManager.destroyScore.ToString();
        }
        else if (hp < 0)
        {
            // ���� �ı��Ѵ�.
            Destroy(gameObject);

            // �ε��� ��븦 �ı��Ѵ�.
            Destroy(otherObject.gameObject);

            // ��ǥ6: �浹�� ���� ȿ���� �����Ѵ�.
            GameObject explosionGO = Instantiate(explosionEff);
            explosionGO.transform.position = gameObject.transform.position;
        }
    }

    // �浹 �� ����
    private void OnCollisionStay(Collision collision)
    {
    }

    // �浹 ����� ����
    private void OnCollisionExit(Collision collision)
    {  
    }
}
