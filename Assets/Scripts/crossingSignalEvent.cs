using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class crossingSignalEvent : MonoBehaviour
{
    public GameObject train;
    public AudioSource crossingSignalAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        var position = train.transform.position;
        train.transform.DOMove(new Vector3(25f, position.y, position.z), 20f).SetEase(Ease.OutQuad).SetDelay(3f);

        SeManager.Instance.Play("電車停車");
        SeManager.Instance.audioSource.volume = 0f;
        SeManager.Instance.audioSource.DOFade(endValue: 1f, duration: 7.5f);

        StartCoroutine(StopCrossingSigna());
    }

    private IEnumerator StopCrossingSigna()
    {
        yield return new WaitForSeconds(20f);
        crossingSignalAudioSource.Stop();
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
