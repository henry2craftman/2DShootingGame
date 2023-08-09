using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 목적: 플레이어가 쌓은 점수(타격점수, 최고점수, 적 파괴점수)를 저장한다.
// 속성: 타격점수, 최고점수, 적 파괴점수
// 목적2: 플레이어가 쌓은 점수를 UI TEXT에 표시한다.
// 속성: 타격점수, 최고점수, 적 파괴점수 UI TEXT
// 목적3: 점수 UI의 Text를 0으로 초기화 해준다.
public class GameManager : MonoBehaviour
{
    public int attackScore;
    public int bestScore;
    public int destroyScore;

    public TMP_Text attackScoreTxt;
    public TMP_Text bestScoreTxt;
    public TMP_Text destroyScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        // 목적3: 점수 UI의 Text를 0으로 초기화 해준다.
        attackScoreTxt.text = "0";
        destroyScoreTxt.text = "0";
        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreTxt.text= bestScore.ToString();
    }
}
