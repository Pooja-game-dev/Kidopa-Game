using UnityEngine;
using Lean.Touch;
public class DragDrop : MonoBehaviour
{
      private bool isDragging = false;
       private Vector3 offset, originalPos;
       private Camera mainCamera;
       public DragDropManager manager;
       private void Start()
     {
         mainCamera = Camera.main;
         originalPos = transform.position;
     }
       private void OnMouseDown()
       {
           isDragging = true;
           Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
           offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
       }
       private void OnMouseDrag()
       {
           if (isDragging)
           {
               Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
               transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
           }
       }
       private void OnMouseUp()
       {
           isDragging = false;

       }

   private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == this.gameObject.tag)
         {
             this.gameObject.SetActive(false);
             Debug.Log(other.transform.position);
             Debug.Log("Success!");
                manager.RegisterSuccess();

           }
   }

    

/* private Vector3 offset;
    private Vector3 originalPos;
    private Camera mainCamera;
    private bool isDragging = false;
    public DragDropManager manager;

    void Start()
    {
        mainCamera = Camera.main;
        originalPos = transform.position;
    }

    void OnEnable()
    {
        LeanTouch.OnFingerDown += HandleFingerDown;
        LeanTouch.OnFingerUp += HandleFingerUp;
        LeanTouch.OnFingerUpdate += HandleFingerUpdate;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
        LeanTouch.OnFingerUp -= HandleFingerUp;
        LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
    }

    private void HandleFingerDown(LeanFinger finger)
    {
        // Raycast to check if this object was touched
        Ray ray = mainCamera.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;

            Vector3 worldPos = mainCamera.ScreenToWorldPoint(finger.ScreenPosition);
            offset = transform.position - new Vector3(worldPos.x, worldPos.y, transform.position.z);
        }
    }

    private void HandleFingerUpdate(LeanFinger finger)
    {
        if (isDragging)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(finger.ScreenPosition);
            transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z) + offset;
        }
    }

    private void HandleFingerUp(LeanFinger finger)
    {
        if (isDragging)
        {
            isDragging = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            this.gameObject.SetActive(false);
            Debug.Log(other.transform.position);
            Debug.Log("Success!");
            manager.RegisterSuccess();
        }
    }*/
}

