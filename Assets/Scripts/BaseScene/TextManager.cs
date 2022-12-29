using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
    [SerializeField] public Text text;

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

    public void Assign(string str)
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

        float minPitch = pitch - 0.02f;
        float maxPitch = pitch + 0f;

        foreach (var charactor in talkingText)
        {
            var str = charactor.ToString();
            Append(str);
            messageCount++;

            // 空文字は音を鳴らさない
            if (String.IsNullOrEmpty(str.Trim()))
            {
                continue;
            }

            if (pitch > 0.01f && messageCount % 2 == 0)
            {
                SeManager.Instance.Play("voice1", Random.Range(minPitch, maxPitch));
            }

            yield return new WaitForSeconds(0.04f);
        }
    }
}
