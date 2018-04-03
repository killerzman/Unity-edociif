using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class windowFocus : MonoBehaviour, IPointerDownHandler
{
    public bool chattext = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        //sets focus on the last clicked window by setting as last sibling
        if(!chattext)
            transform.parent.SetAsLastSibling();
        else
        {
            transform.parent.transform.parent.SetAsLastSibling();
        }
    }
}
