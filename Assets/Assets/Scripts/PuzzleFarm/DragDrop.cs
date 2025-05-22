using UnityEngine;
using Lean.Touch;
public class DragDrop : MonoBehaviour
{
  
    private bool isDragging = false;
    private Vector3 offset, originalPos;
    private Camera mainCamera;
    private LeanFinger activeFinger;

    public DragDropManager manager;

    void Start()
    {
        mainCamera = Camera.main;
        originalPos = transform.position;
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

    void HandleFingerDown(LeanFinger finger)
    {
        // Raycast to check if this object was touched
        Ray ray = mainCamera.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            activeFinger = finger;
            isDragging = true;

            Vector3 fingerWorldPos = GetWorldPosition(finger);
            offset = transform.position - fingerWorldPos;
        }
    }

    void HandleFingerUpdate(LeanFinger finger)
    {
        if (isDragging && finger == activeFinger)
        {
            Vector3 fingerWorldPos = GetWorldPosition(finger);
            transform.position = fingerWorldPos + offset;
        }
    }

    void HandleFingerUp(LeanFinger finger)
    {
        if (finger == activeFinger)
        {
            isDragging = false;
            activeFinger = null;
        }
    }

    Vector3 GetWorldPosition(LeanFinger finger)
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(finger.ScreenPosition);
        worldPos.z = 0; // Keep it in 2D plane
        return worldPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            // Deactivate this object
            this.gameObject.SetActive(false);

            // Show the target sprite (e.g., drop zone)
            SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.enabled = true;

            Debug.Log("Dropped at: " + other.transform.position);
            Debug.Log("Success!");

            manager.RegisterSuccess();
        }
    }

   

}

