using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Hatena : MonoBehaviour
{
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

    void Update()
    {
        if (spriteRender.enabled && Input.GetButtonDown("決定"))
        {
            if (string.IsNullOrEmpty(TextManager.Instance.text.text))
            {
                StartCoroutine(Speech());
            }
        }
    }

    IEnumerator Speech()
    {
        foreach (var text in speechTexts)
        {
            yield return TextManager.Instance.TalkText(text);
            yield return new WaitUntil(() => Input.GetButtonDown("決定"));
            yield return null;
        }
        TextManager.Instance.Assign("");
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
