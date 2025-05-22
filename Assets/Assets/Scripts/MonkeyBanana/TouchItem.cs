using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Touch;
public class TouchItem : MonoBehaviour
{    
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] private float _speed = 10f;
    private bool _isDragging = false;
    private LeanFinger _dragFinger;

    void Awake()
    {
        _cam = Camera.main;
        Debug.Log("start");
    }
    void OnEnable()
    {
        LeanTouch.OnFingerDown += HandleFingerDown;
        LeanTouch.OnFingerUpdate += HandleFingerUpdate;
        LeanTouch.OnFingerUp += HandleFingerUp;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
        LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
        LeanTouch.OnFingerUp -= HandleFingerUp;
    }

    private void HandleFingerDown(LeanFinger finger)
    {
        Ray ray = _cam.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            _isDragging = true;
            _dragFinger = finger;

            Vector3 worldPos = GetWorldPos(finger);
            _dragOffset = transform.position - worldPos;
        }
    }

    private void HandleFingerUpdate(LeanFinger finger)
    {
        if (_isDragging && finger == _dragFinger)
        {
            Vector3 targetPos = GetWorldPos(finger) + _dragOffset;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
        }
    }

    private void HandleFingerUp(LeanFinger finger)
    {
        if (finger == _dragFinger)
        {
            _isDragging = false;
            _dragFinger = null;
        }
    }

    private Vector3 GetWorldPos(LeanFinger finger)
    {
        Vector3 pos = _cam.ScreenToWorldPoint(finger.ScreenPosition);
        pos.z = 0;
        return pos;
    }
}
