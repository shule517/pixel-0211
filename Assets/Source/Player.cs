using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    /// <summary> 移動操作を受け付けるタッチエリア </summary>
    [SerializeField]
    private DragHandler _moveController;

    /// <summary> 移動速度（m/秒） </summary>
    [SerializeField]
    private float _movePerSecond = 7f;

    /// <summary> 移動操作としてタッチ開始したスクリーン座標 </summary>
    private Vector2 _movePointerPosBegin;

    private Vector3 _moveVector;

    AudioSource audioSourceSeWalk;
    Animator animator;
    // Tween tween;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSeWalk = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    /// <summary> 起動時 </summary>
    private void Awake()
    {
        _moveController.OnBeginDragEvent += OnBeginDragMove;
        _moveController.OnDragEvent += OnDragMove;
        _moveController.OnEndDragEvent += OnEndDragMove;
    }

    /// <summary> 更新処理 </summary>
    private void Update()
    {
        UpdateMove(_moveVector);

        // クリックしたオブジェクトまで移動
        if (Input.GetMouseButtonDown(0)) {
            GameObject clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d) {
                clickedGameObject = hit2d.transform.gameObject;

                var moveDistance = hit2d.transform.position.x - transform.position.x;
                var second = Math.Abs(moveDistance / _movePerSecond);
                
                // 歩き始めた
                audioSourceSeWalk.Play();
                nowAnime = walkAnime;

                // 移動を中断
                transform.DOKill();

                if (moveDistance > 0)
                {
                    // 右に移動
                    Vector3 localScale = transform.localScale;
                    if (localScale.x < 0)
                    {
                        localScale.x = localScale.x * -1;
                        transform.localScale = localScale;
                    }
                }
                else if (moveDistance < 0)
                {
                    // 左に移動
                    Vector3 localScale = transform.localScale;
                    if (localScale.x > 0)
                    {
                        localScale.x = localScale.x * -1;
                        transform.localScale = localScale;
                    }
                }

                // 移動
                transform.DOLocalMove(new Vector3(hit2d.transform.position.x, transform.position.y, 0), second).SetEase(Ease.Linear).OnComplete(() => {
                    // 歩き終わった
                    audioSourceSeWalk.Stop();
                    nowAnime = standAnime;
                });
            } 

            Debug.Log(clickedGameObject);
        }
    }

    private void FixedUpdate()
    {
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }
    }

    ////////////////////////////////////////////////////////////
    /// 移動操作
    ////////////////////////////////////////////////////////////
    #region Move

    public static string standAnime = "PlayerStand";
    public static string walkAnime = "PlayerWalk";

    string nowAnime = standAnime;
    string oldAnime = standAnime;

    /// <summary> ドラッグ操作開始（移動用） </summary>
    private void OnBeginDragMove(PointerEventData eventData)
    {
        // タッチ開始位置を保持
        _movePointerPosBegin = eventData.position;

        // 歩き始めた
        audioSourceSeWalk.Play();
        nowAnime = walkAnime;

        // 移動を中断
        transform.DOKill();
    }

    /// <summary> ドラッグ操作中（移動用） </summary>
    private void OnDragMove(PointerEventData eventData)
    {
        // タッチ開始位置からのスワイプ量を移動ベクトルにする
        var vector = eventData.position - _movePointerPosBegin;
        // _moveVector = new Vector3(vector.x, 0f, vector.y);
        _moveVector = new Vector3(vector.x, 0f, 0f); // 左右だけに移動できる

        if (vector.x > 0)
        {
            // 右に移動
            Vector3 localScale = transform.localScale;
            if (localScale.x < 0)
            {
                localScale.x = localScale.x * -1;
                transform.localScale = localScale;
            }
        }
        else if (vector.x < 0)
        {
            // 左に移動
            Vector3 localScale = transform.localScale;
            if (localScale.x > 0)
            {
                localScale.x = localScale.x * -1;
                transform.localScale = localScale;
            }
        }
    }

    private void UpdateMove(Vector3 vector)
    {
        // 現在向きを基準に、入力されたベクトルに向かって移動
        transform.position += transform.rotation * vector.normalized * _movePerSecond * Time.deltaTime;
    }

    /// <summary> ドラッグ操作終了（移動用） </summary>
    private void OnEndDragMove(PointerEventData eventData)
    {
        // 移動ベクトルを解消
        _moveVector = Vector3.zero;

        // 歩き終わった
        audioSourceSeWalk.Stop();
        nowAnime = standAnime;
    }
    #endregion

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
