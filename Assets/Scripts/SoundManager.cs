using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: BGM, 폭발 사운드, 아이템 획득 사운드를 재생한다.
// 필요속성: BGM, 폭발 사운드, 아이템 획득 사운드 오디오클립
public class SoundManager : MonoBehaviour
{
    public enum SoundName
    {
        Explosion0 = 0,
        Explosion1 = 1,
        Attack0 = 2,
        Attack1 = 3,
        BGM1 = 4,
        BGM2 = 5
    }

    public AudioSource bgmAudioSource;
    public AudioSource effAudioSource;

    public List<AudioClip> bgmAudioClips = new List<AudioClip>();
    public List<AudioClip> explosionAudioClips = new List<AudioClip>();
    public List<AudioClip> itemAudioClips = new List<AudioClip>();
    public List<AudioClip> fireAudioClips = new List<AudioClip>();

    private void Start()
    {
        int randBGM = Random.Range(0, bgmAudioClips.Count);
        bgmAudioSource.clip = bgmAudioClips[randBGM];
    }
}
