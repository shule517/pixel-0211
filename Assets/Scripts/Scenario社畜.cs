using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class Scenario社畜 : MonoBehaviour
{
    public Light2D light2D;

    [SerializeField]
    static int days = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        StartCoroutine(TypingBgm());

        // 暗転から復帰
        yield return DOTween.Sequence().Append(DOTween.To(() => 0f, (float x) => light2D.intensity = x, 1f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();
        yield return new WaitForSeconds(4.5f);

        if (days == 0)
        {
            TextManager.Instance.Speech("えっ… (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("これ今日中ですか…？ (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("あっ はい。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("わかりました。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("なんとかします。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Assign("");
            yield return new WaitForSeconds(4.5f);

            // 暗転
            yield return DOTween.Sequence().Append(DOTween.To(() => 1f, (float x) => light2D.intensity = x, 0f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();

            days++;
            SceneManager.LoadScene("OpeningScene");
        }
        else
        {
            TextManager.Instance.Speech("えっ… (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("よるちゃん やめちゃうんですか… (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("そうなんですね。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            TextManager.Instance.Speech("わかりました。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;

            // ３回目だけ 帰る意思 分岐
            TextManager.Instance.Speech("帰ろう。 (A)", 0.8f);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;
            TextManager.Instance.Assign("");

            // 暗転
            yield return DOTween.Sequence().Append(DOTween.To(() => 1f, (float x) => light2D.intensity = x, 0f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();

            days++;
            SceneManager.LoadScene("夜道Scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextManager.Instance.Speech("");
            SceneManager.LoadScene("夜道Scene");
        }
    }

    private IEnumerator TypingBgm()
    {
        var typingTexts = new string[] {
            "    ",
            "        ",
            "                    ",
        };
        var talkingText = typingTexts[Random.Range(0, typingTexts.Length)];

        StartCoroutine(TypingSe(2.5f, talkingText));
        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        StartCoroutine(TypingBgm());
    }

    private IEnumerator TypingSe(float pitch, string talkingText)
    {
        int messageCount = 0;

        float minPitch = pitch - 0.5f;
        float maxPitch = pitch + 0.5f;

        foreach (var str in talkingText)
        {
            if (messageCount % 2 == 0)
            {
                SeManager.Instance.Play("カーソル移動2", Random.Range(minPitch, maxPitch));
            }
            messageCount++;

            yield return new WaitForSeconds(0.04f);
        }
    }
}
