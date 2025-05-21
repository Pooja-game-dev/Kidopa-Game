using UnityEngine;

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

   

}

