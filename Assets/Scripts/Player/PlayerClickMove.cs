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
        // PlayerInput���C���X�^���X��
        _playerinput = new Playerinput();
        // �U�����\�b�h��InputSystem�̃f���Q�[�g�ɒǉ�
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
        // �N���b�N�� Ray ���΂�
        // �J�����̈ʒu �� �}�E�X�ŃN���b�N�����ꏊ�� Ray ���΂��悤�ɐݒ肷��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Ray �������������ǂ����ňقȂ鏈��������iPhysics.Raycast() �ɂ͂�������I�[�o�[���[�h������̂Œ��ӂ��邱�Ɓj
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Ray �������������́A�����������W�܂ŐԂ���������
            Debug.DrawLine(ray.origin, hit.point, _debugRayColorOnHit);
            // _marker ���A�T�C������Ă�����A������ړ�����
            if (_marker)
            {
                _marker.transform.position = hit.point + _markerOffset;
                _nav.SetDestination(_marker.transform.position);
            }
        }
        else
        {
            // Ray ��������Ȃ������ꍇ�́ARay �̕����ɔ�����������
            Debug.DrawRay(ray.origin, ray.direction * _debugRayLength);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _marker.SetActive(false);
    }
}