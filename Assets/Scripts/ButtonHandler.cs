using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    
    public virtual void OnPointerDown(PointerEventData eventData)
    { }

    public virtual void OnPointerUp(PointerEventData eventData)
    { }
    
}
