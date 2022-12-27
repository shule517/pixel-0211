using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class crossingSignalEvent : MonoBehaviour
{
    public GameObject train;

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
        var position = train.transform.position;
        train.transform.DOMove(new Vector3(25f, position.y, position.z), 20f).SetEase(Ease.OutQuad).SetDelay(3f);

        Debug.Log("OnTriggerEnter2D");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
