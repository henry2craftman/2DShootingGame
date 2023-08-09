using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ����� �Է�(Space)�� �޾� �Ѿ��� ����� �ʹ�.
// ����1: �Է��� �ް� �ʹ�.
// ����2: �Ѿ��� ����� �ʹ�.

// ��ǥ2: �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
// �Ӽ�: ��ų����
// �ܰ�1. �������� �Ծ��ٸ�
// �ܰ�2. ��ų������ 1 �ö󰣴�.
// �ܰ�3. �������� �ı��Ѵ�.
// �ܰ�4. ������ ����Ʈ�� �����Ѵ�.
// �ܰ�5. �߻�� SoundManger�� AudioSource�� ����Ѵ�.
// �Ӽ�: SoundManager
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;
    public int degree = 15;

    // �Ӽ�: SoundManager
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����1: �Է��� �ް� �ʹ�.
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
            case 3:
                ExcuteSkill3(degree);
                break;
        }

        // �ܰ�5. �߻�� SoundManger�� AudioSource�� ����Ѵ�.
        soundManager.effAudioSource.clip = soundManager.fireAudioClips[0];
        soundManager.effAudioSource.Play();

        // �Ѱ��� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill0()
        {
            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bulletGO = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bulletGO.transform.position = gunPos.transform.position;
        }

        // �ΰ��� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill1()
        {
            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bulletGO = Instantiate(bullet);
            GameObject bulletGO1 = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f , 0, 0);
            bulletGO1.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
        }

        // ������ �Ѿ��� �߻�ȴ�.
        // 1, 2, 3 �Ѿ� �� 1, 3 �Ѿ��� ���� Z������ -30��, 30�� ȸ�� �� �߻�ȴ�.
        void ExcuteSkill2()
        {
            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bulletGO = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bulletGO.transform.position = gunPos.transform.position;

            // ����2: �Ѿ��� ����� �ʹ�.
            GameObject bulletGO2 = Instantiate(bullet);
            GameObject bulletGO3 = Instantiate(bullet);

            // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
            bulletGO2.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO2.transform.rotation = Quaternion.Euler(0, 0, 30);
            bulletGO2.GetComponent<Bullet>().dir = bulletGO2.transform.up;


            bulletGO3.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
            bulletGO3.transform.rotation = Quaternion.Euler(0, 0, -30);
            bulletGO3.GetComponent<Bullet>().dir = bulletGO3.transform.up;
        }

        
        // 15�� ���ݸ��� �� 24���� �Ѿ��� 360�� �߻��Ѵ�.
        void ExcuteSkill3(int _degree)
        {
            int numOfBullet = 360 / degree;

            for (int i = 0; i < numOfBullet; i++)
            {
                // ����2: �Ѿ��� ����� �ʹ�.
                GameObject bulletGO = Instantiate(bullet);

                // ����3: �Ѿ��� ��ġ�� �÷��̾��� ��ġ�� �����ְ� �ʹ�.
                bulletGO.transform.position = gunPos.transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
                bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;
            }
        }
    }

    // ��ǥ2: �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
    private void OnTriggerEnter(Collider other)
    {
        // �ܰ�1. �������� �Ծ��ٸ�
        if (other.gameObject.tag == "Item")
        {
            // �ܰ�2. ��ų������ 1 �ö󰣴�.(�ִ� ��ų������ �ʰ��ϱ� ������)
            if(skillLevel < 3)
                skillLevel++;

            // �ܰ�3. �������� �ı��Ѵ�.
            Destroy(other.gameObject);
        }
    }
}
