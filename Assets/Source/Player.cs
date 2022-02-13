using UnityEngine;
using UnityEngine.EventSystems;

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

    public AudioClip soundWalk;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    }

    ////////////////////////////////////////////////////////////
    /// 移動操作
    ////////////////////////////////////////////////////////////
    #region Move

    /// <summary> ドラッグ操作開始（移動用） </summary>
    private void OnBeginDragMove(PointerEventData eventData)
    {
        // タッチ開始位置を保持
        _movePointerPosBegin = eventData.position;
        audioSource.Play();
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
        audioSource.Stop();
    }
    #endregion

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
