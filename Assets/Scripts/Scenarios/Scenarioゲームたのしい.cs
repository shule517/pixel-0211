using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Scenarioゲームたのしい : MonoBehaviour
{
    public Light2D light2D;

    IEnumerator Start()
    {
        // 最初は真っ暗
        light2D.intensity = 0;

        // 目をあけた
        yield return DOTween.Sequence().Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();

        yield return new WaitForSeconds(2.5f);

        TextManager.Instance.Speech("めちゃくちゃ いいゲームだった…！ (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(0.8f);

        TextManager.Instance.Speech("ドット絵も、音楽も、ストーリーも── (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(0.8f);

        TextManager.Instance.Speech("すべてが つながっていて── (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(0.8f);

        TextManager.Instance.Speech("最高な ふんいきだった！！ (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(0.8f);

        TextManager.Instance.Speech("人の心を動かすようなゲーム── (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(0.8f);

        TextManager.Instance.Speech("いつか 自分も 作れたらなぁ… … … (A)", 0.8f);
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;
        TextManager.Instance.Assign("");

        yield return new WaitForSeconds(2.8f);

        BgmManager.Instance.Play("バイブ音＃01");
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(2.5f);

        TextManager.Instance.Speech("─ アラームを止める ─ (A)", 0f);

        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        // アラームを止める
        BgmManager.Instance.Stop();
        TextManager.Instance.Assign("");

        SceneManager.LoadScene("ワンルームScene");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
