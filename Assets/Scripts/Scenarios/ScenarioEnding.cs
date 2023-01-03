using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ScenarioEnding : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameObject museum;
    public Light2D light2D;
    public AudioSource audioSource;

    IEnumerator Start()
    {
        // 最初は真っ暗
        light2D.intensity = 0;
        gameObjects.ForEach((gameObject) => gameObject.SetActive(false));
        gameObjects.First().SetActive(true);

        yield return new WaitForSeconds(1.5f); // BaseScene読み込み待ち
        BgmManager.Instance.Play("audiostock_892577_sample");

        yield return new WaitForSeconds(15f);
        yield return DOTween.Sequence().Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 0.1f).SetEase(Ease.InQuad));

        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(7.5f); // 15s 22.5s 30s 37.5s 46s
            gameObject.SetActive(false);
        }

        // 無音＆暗くする
        light2D.intensity = 0;
        yield return new WaitForSeconds(2f);
        BgmManager.Instance.Stop();

        yield return new WaitForSeconds(1f);

        // 美術館の入り口を表示する
        museum.SetActive(true);
        yield return DOTween.Sequence().Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetEase(Ease.InQuad));

        yield return new WaitForSeconds(5.5f);

        // 暗くする
        yield return DOTween.Sequence().Append(DOTween.To(() => 1, (float x) => light2D.intensity = x, 0f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();

        yield return new WaitForSeconds(1.5f);

        TextManager.Instance.Speech("プレイしていただき ありがとうございました！");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        TextManager.Instance.Speech("この作品は 自分のつらかった過去が \nモチーフとなっています。");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        TextManager.Instance.Speech("同じように つらい思いをしている人が、");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        TextManager.Instance.Speech("前向きになってくれるような\n作品をめざしています。");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        TextManager.Instance.Speech("だれかに ひびいてくれたら うれしいです。");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        TextManager.Instance.Speech("良い作品になれるように\nこれから がんばっていきます！       はる");
        yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        yield return null;

        yield return new WaitForSeconds(3.5f);

        // タイトルに戻る
        SceneManager.LoadScene("TitleScene");
    }

    void Update()
    {
    }
}
