using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class btnSlot : MonoBehaviour, IDropHandler 
{


    public void OnDrop(PointerEventData eventData)
    {

        /* if (eventData.pointerDrag != null)
         {
             eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                 transform.GetComponent<RectTransform>().anchoredPosition;
             eventData.pointerDrag.GetComponent<Image>().color = Color.green;
         }*/
        
        if (eventData.pointerDrag != null)
        {
            // Get the tag of the dragged object
            string draggedTag = eventData.pointerDrag.tag;
            // Get the tag of the slot
            string slotTag = gameObject.tag;
            // Check if the tags match
            if (draggedTag == slotTag)
            {
                // If they match, set the position and change color
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    transform.GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<Image>().color = Color.green;
            }
            else
            {
                // Optionally, you can reset the position or change color if they don't match
                eventData.pointerDrag.GetComponent<Image>().color = Color.red; // Indicate a mismatch
            }
        }
    
        
    }
}
