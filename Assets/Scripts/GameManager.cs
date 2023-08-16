using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ����: �÷��̾ ���� ����(Ÿ������, �ְ�����, �� �ı�����)�� �����Ѵ�.
// �Ӽ�: Ÿ������, �ְ�����, �� �ı�����
// ����2: �÷��̾ ���� ������ UI TEXT�� ǥ���Ѵ�.
// �Ӽ�: Ÿ������, �ְ�����, �� �ı����� UI TEXT
// ����3: ���� UI�� Text�� 0���� �ʱ�ȭ ���ش�.

// 목적: 게임종료가 되면 EndingScreen을 활성화 시키고, EndingScreen에 최고 점수를 표시한다.
// 필요속성: 엔딩스크린, 최고점수

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int attackScore;
    private int destroyScore;
    private int bestScore;

    public int AttackScore
    {
        get
        {
            return attackScore;
        }
        set
        {
            attackScore = value;
            attackScoreTxt.text = attackScore.ToString();
        }
    }
    public int DestroyScore
    {
        get
        {
            return destroyScore;
        }
        set
        {
            destroyScore = value;
            destroyScoreTxt.text = destroyScore.ToString();
        }
    }
    public int BestScore
    {
        get
        {
            return bestScore;
        }
        set
        {
            bestScore = value;
            bestScoreTxt.text = bestScore.ToString();
        }
    }

    public TMP_Text attackScoreTxt;
    public TMP_Text bestScoreTxt;
    public TMP_Text destroyScoreTxt;

    public GameObject player;

    // 필요속성: 엔딩스크린
    public EndingScreen EndingScreen;

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

    public void GameOver()
    {
        EndingScreen.gameObject.SetActive(true);
        EndingScreen.scoreTxt.text = bestScoreTxt.text + " points";
    }

    public void Restart()
    {
        EndingScreen.gameObject.SetActive(false);

        player.SetActive(true);

        // 점수 초기화
        AttackScore = DestroyScore = BestScore = 0;
        player.GetComponent<PlayerMove>().hp = 10;
        player.GetComponent<PlayerFire>().skillLevel = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
