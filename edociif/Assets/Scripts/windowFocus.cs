using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class windowFocus : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        //sets focus on the last clicked window by setting as last sibling
        transform.parent.SetAsLastSibling();
    }
}
