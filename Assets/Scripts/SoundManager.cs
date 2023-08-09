using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: BGM, 폭발 사운드, 아이템 획득 사운드를 재생한다.
// 필요속성: BGM, 폭발 사운드, 아이템 획득 사운드 오디오클립
public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioSource effAudioSource;

    public List<AudioClip> bgmAudioClips = new List<AudioClip>();
    public List<AudioClip> explosionAudioClips = new List<AudioClip>();
    public List<AudioClip> itemAudioClips = new List<AudioClip>();

}
