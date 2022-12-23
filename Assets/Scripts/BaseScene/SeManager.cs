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

        Debug.Log("audioSource = GetComponent<AudioSource>();");
        audioSource = GetComponent<AudioSource>();
        Debug.Log("audioSource: " + audioSource);
        audioClips = Resources.LoadAll<AudioClip>("SE");
        audioClipDict = audioClips.ToDictionary(clip => clip.name, clip => clip);
    }

    public void Play(string filePath, float pitch = 1f, float volumeScale = 1f)
    {
        Debug.Log("1 audioSource: " + audioSource);
        audioSource.pitch = pitch;
        Debug.Log("2 audioSource.pitch: " + audioSource.pitch);
        Debug.Log("2 audioClipDict: " + audioClipDict);

        var audioClip = audioClipDict[filePath];
        Debug.Log("3");
        audioSource.PlayOneShot(audioClip, volumeScale);
        Debug.Log("4");
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
