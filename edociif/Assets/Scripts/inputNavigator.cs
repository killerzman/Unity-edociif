using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class inputNavigator : MonoBehaviour
{
    EventSystem system;
   
    void Start(){
        system = EventSystem.current;
    }
   
    void Update(){
        //if tab has been pressed and there is no game object selected, don't do anythhing
        if (system.currentSelectedGameObject == null || !Input.GetKeyDown (KeyCode.Tab))
            return;
 
        Selectable current = system.currentSelectedGameObject.GetComponent<Selectable>();
        if (current == null)
            return;

        //define going up input fields by pressing leftshift or rightshift
        bool up = Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
        Selectable next = up ? current.FindSelectableOnUp() : current.FindSelectableOnDown();
 
        //if next object is null, define next as current object
        if (next == null){
            next = current;
 
            Selectable pnext;

            //finding next upwards or downwards object that isn't null
            if(up){ 
				while((pnext = next.FindSelectableOnDown()) != null) next = pnext;
			}
            else{ 
				while((pnext = next.FindSelectableOnUp()) != null) next = pnext;
			}
        }
 
        // simulate Inputfield MouseClick
        InputField inputfield = next.GetComponent<InputField>();
        if (inputfield != null){
			inputfield.OnPointerClick(new PointerEventData(system));
		}
 
        //select the next item in the tab order of our direction
        system.SetSelectedGameObject(next.gameObject);
    }
}