using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scenario駅ホーム_電車に乗る : MonoBehaviour
{
    public GameObject train;
    public GameObject doorLeft;
    public GameObject doorRight;
    public GameObject player;
    public bool IsTalking = false;
    public Light2D light2D;
    public Light2D light2DPlayer;

    public List<string> speechTexts;
    public float interval = 1.5f;
    private SpriteRenderer spriteRender;

    void Start()
    {
        // 初期は非表示
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.enabled = false;

        // ぴょんぴょん
        transform.DOMoveY(transform.position.y + 0.5f, interval).SetLoops(-1, LoopType.Yoyo);
    }

    IEnumerator TakeTrain()
    {
        // !を非表示
        spriteRender.enabled = false;

        // はるが電車に乗る
        Player.Instance.NowAnime = Player.walkAnime;
        yield return player.transform.DOMove(new Vector3(player.transform.position.x, -1.43f, player.transform.position.z), 1f).OnComplete(() => { player.GetComponent<Renderer>().sortingOrder = 8; }).WaitForCompletion();
        player.transform.parent = train.transform;

        // 電車に乗るので、影を消す
        Player.Instance.NowAnime = Player.standKageNashiAnime;

        yield return new WaitForSeconds(2f);

        // セリフ
        yield return Speech();

        // 今のBGMをフェードアウト
        BgmManager.Instance.audioSource.DOFade(endValue: 0f, duration: 7.5f).WaitForCompletion();

        // 扉が閉まる
        SeManager.Instance.Play("電車のドアが開く1");
        var sequence_left = DOTween.Sequence();
        sequence_left.Append(doorLeft.transform.DOLocalMove(new Vector3(0.045f, 0f, 0f), 1.3f).SetEase(Ease.Linear));
        sequence_left.Append(doorLeft.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1.2f).SetEase(Ease.Linear));

        var sequence_right = DOTween.Sequence();
        sequence_right.Append(doorRight.transform.DOLocalMove(new Vector3(-0.045f, 0f, 0f), 1.3f).SetEase(Ease.Linear));
        sequence_right.Append(doorRight.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 1.2f).SetEase(Ease.Linear));
        yield return sequence_left.WaitForCompletion();

        // 電車発車
        SeManager.Instance.Play("電車発車1");

        // 暗転の予約
        DOTween.Sequence().Append(DOTween.To(() => 1f, (float x) => light2D.intensity = x, 0f, 5f).SetEase(Ease.InQuad)).SetDelay(18f);
        DOTween.Sequence().Append(DOTween.To(() => 1f, (float x) => light2DPlayer.intensity = x, 0f, 5f).SetEase(Ease.InQuad)).SetDelay(18f);

        // 電車の移動
        yield return train.transform.DOMoveX(train.transform.position.x + 400f, 25f).SetEase(Ease.InCubic).SetDelay(3f).WaitForCompletion();
        //yield return train.transform.DOMoveX(train.transform.position.x + 100f, 15f).SetEase(Ease.InCubic).SetDelay(3f).WaitForCompletion();

        //yield return new WaitForSeconds(2f);

        //TextManager.Instance.Speech("帰るのが こわい…");
        //yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        //yield return null;

        //TextManager.Instance.Speech("帰ったら、明日がきちゃう…");
        //yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        //yield return null;

        //TextManager.Instance.Speech("また朝が来て 仕事がはじまる…");
        //yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        //yield return null;

        //TextManager.Instance.Speech("かえりたく…   ない…");
        //yield return new WaitUntil(() => Input.GetButtonDown("決定"));
        //yield return null;

        // 電車の発車音をフェードアウト
        SeManager.Instance.audioSource.DOFade(endValue: 0f, duration: 7.5f).OnComplete(() => {
            SeManager.Instance.Stop();
            SeManager.Instance.audioSource.volume = 1f;
        });

        // エンディングを流す
        BgmManager.Instance.Play("audiostock_822608_sample");
        BgmManager.Instance.audioSource.volume = 0;
        BgmManager.Instance.audioSource.DOFade(endValue: 1f, duration: 7.5f);

        //yield return new WaitForSeconds(21f - 7.5f);

        SceneManager.LoadScene("しみじみエンディングScene");

        //Speech();

        // ドアが閉まって20秒後に、エンディングに変わる
        //sequence_left.OnComplete(() => { DOTween.Sequence().SetDelay(20f).OnComplete(() => { SceneManager.LoadScene("しみじみエンディングScene"); }); });

        //train.transform.DOMoveX(train.transform.position.x + 100f, 20f).SetEase(Ease.InQuad).SetDelay(3f);
        //if (!TextManager.Instance.IsTalking)
        //{
        //    Speech();
        //}
        yield return null;
    }

    void Update()
    {
        if (spriteRender.enabled && Input.GetButtonDown("決定"))
        {
            if (!IsTalking)
            {
                IsTalking = true;
                StartCoroutine(TakeTrain());
            }
        }
    }

    IEnumerator Speech()
    {
        int index = 0;
        foreach (var text in speechTexts)
        {
            if (index == speechTexts.Count - 3)
            {
                // うるうる
                Player.Instance.NowAnime = Player.uruuruAnime;
            }

            if (index == speechTexts.Count - 1)
            {
                // 最後のセリフで涙
                Player.Instance.NowAnime = Player.namidaAnime;
                var sequence_left = DOTween.Sequence().SetDelay(1.5f).OnComplete(() => {
                    // 涙を流し終わったら、うるうる
                    Player.Instance.NowAnime = Player.uruuruAnime;
                });
            }

            yield return TextManager.Instance.Speech2(text);
            index++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 近くに来たら表示
        spriteRender.enabled = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // 離れたら非表示
        spriteRender.enabled = false;
        TextManager.Instance.Assign("");
    }
}
