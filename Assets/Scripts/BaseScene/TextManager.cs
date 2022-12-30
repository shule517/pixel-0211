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
        StartCoroutine(TalkText(str, audioPitch));
    }

    public void Assign(string str)
    {
        text.text = str;
    }

    void Append(string str)
    {
        text.text += str;
    }

    public IEnumerator TalkText(string talkingText, float audioPitch = 1f)
    {
        int messageCount = 0;
        Assign("");

        float minPitch = audioPitch - 0.02f;
        float maxPitch = audioPitch + 0f;

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

            if (audioPitch > 0.01f && messageCount % 2 == 0)
            {
                SeManager.Instance.Play("voice1", Random.Range(minPitch, maxPitch));
            }

            yield return new WaitForSeconds(0.04f);
        }
    }
}
