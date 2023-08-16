using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ����: �÷��̾ ���� ����(Ÿ������, �ְ�����, �� �ı�����)�� �����Ѵ�.
// �Ӽ�: Ÿ������, �ְ�����, �� �ı�����
// ����2: �÷��̾ ���� ������ UI TEXT�� ǥ���Ѵ�.
// �Ӽ�: Ÿ������, �ְ�����, �� �ı����� UI TEXT
// ����3: ���� UI�� Text�� 0���� �ʱ�ȭ ���ش�.

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int attackScore;

    public int AttackScore
    {
        get
        {
            return attackScore;
        }
        set
        {
            attackScore += value;
            attackScoreTxt.text = attackScore.ToString();
        }
    }


    private int bestScore;
    private int destroyScore;

    public TMP_Text attackScoreTxt;
    public TMP_Text bestScoreTxt;
    public TMP_Text destroyScoreTxt;

    public GameObject player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ����3: ���� UI�� Text�� 0���� �ʱ�ȭ ���ش�.
        attackScoreTxt.text = "0";
        destroyScoreTxt.text = "0";
        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreTxt.text= bestScore.ToString();
    }

    public void SetDestroyScore()
    {
        destroyScore += 100;
        destroyScoreTxt.text = destroyScore.ToString();
    }

    public void SetBestScore()
    {
        bestScore = attackScore + destroyScore;
        bestScoreTxt.text = bestScore.ToString();

        // 플레이어 파괴시 최고 점수라면 최고점수를 플팻폼 레지스트리에 저장한다.
        int tempBestScore = PlayerPrefs.GetInt("Best Score");
        if (bestScore > tempBestScore)
        {
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public int GetScore()
    {
        return bestScore;
    }
}
