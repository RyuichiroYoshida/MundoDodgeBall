using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerClickMove : MonoBehaviour
{
    [SerializeField] private GameObject _marker;
    [SerializeField] private Color _debugRayColorOnHit = Color.red;
    [SerializeField] private float _debugRayLength = 100f;
    [SerializeField] private Vector3 _markerOffset = Vector3.up * 0.01f;
    private Playerinput _playerinput;
    private NavMeshAgent _nav;

    private void Awake()
    {
        // PlayerInputをインスタンス化
        _playerinput = new Playerinput();
        // 攻撃メソッドをInputSystemのデリゲートに追加
        _playerinput.Player.ClickMove.performed += OnClickMove;
        _playerinput.Enable();
    }
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
    }
    private void OnDestroy()
    {
        _playerinput.Player.ClickMove.performed -= OnClickMove;
        _playerinput?.Dispose();
    }

    private void OnClickMove(InputAction.CallbackContext context)
    {
        _marker.SetActive(true);
        // クリックで Ray を飛ばす
        // カメラの位置 → マウスでクリックした場所に Ray を飛ばすように設定する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Ray が当たったかどうかで異なる処理をする（Physics.Raycast() にはたくさんオーバーロードがあるので注意すること）
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Ray が当たった時は、当たった座標まで赤い線を引く
            Debug.DrawLine(ray.origin, hit.point, _debugRayColorOnHit);
            // _marker がアサインされていたら、それを移動する
            if (_marker)
            {
                _marker.transform.position = hit.point + _markerOffset;
                _nav.SetDestination(_marker.transform.position);
            }
        }
        else
        {
            // Ray が当たらなかった場合は、Ray の方向に白い線を引く
            Debug.DrawRay(ray.origin, ray.direction * _debugRayLength);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _marker.SetActive(false);
    }
}