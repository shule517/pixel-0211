using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SeManager : SingletonMonoBehaviour<SeManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private Dictionary<string, AudioClip> audioClipDict;

    void Start()
    {
        // 次のシーンでも破棄しない
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioClips = Resources.LoadAll<AudioClip>("SE");
        audioClipDict = audioClips.ToDictionary(clip => clip.name, clip => clip);
    }

    public void Play(string filePath, float pitch = 1f)
    {
        audioSource.pitch = pitch;

        var audioClip = audioClipDict[filePath];
        audioSource.PlayOneShot(audioClip);
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
