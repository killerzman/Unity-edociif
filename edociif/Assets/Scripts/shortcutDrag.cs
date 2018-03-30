using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shortcutDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    public void OnDrag(PointerEventData eventData){
        //moves the object by adding its' position to how much the cursor has moved on screen
        //casting eventData to Vector3 because the third coordinate is needed
        transform.position += (Vector3)eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //sets focus on the last clicked shortcut
        transform.SetAsLastSibling();
    }
}