using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
    [SerializeField] private Text text;

    void Start()
    {
        // 次のシーンでも破棄しない
        DontDestroyOnLoad(transform.parent.gameObject);
        DontDestroyOnLoad(gameObject);

        text = GetComponent<Text>();
    }

    public void Speech(string str, float audioPitch = 1f)
    {
        StartCoroutine(TalkText(audioPitch, str));
    }

    void Assign(string str)
    {
        text.text = str;
    }

    void Append(string str)
    {
        text.text += str;
    }

    public IEnumerator TalkText(float pitch, string talkingText)
    {
        int messageCount = 0;
        Assign("");

        float minPitch = pitch - 0.5f;
        float maxPitch = pitch + 0.5f;

        foreach (var str in talkingText)
        {
            if (messageCount % 2 == 0)
            {
                SeManager.Instance.Play("決定ボタンを押す44", Random.Range(minPitch, maxPitch));
            }
            Append(str.ToString());
            messageCount++;

            yield return new WaitForSeconds(0.04f);
        }
    }
}
