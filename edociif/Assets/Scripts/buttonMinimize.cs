using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonMinimize : MonoBehaviour {

	public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(minimizeWindow);
    }

    void minimizeWindow()
    {
        //referencing to windowProp script that the window is minimized
        transform.parent.GetComponent<windowProp>().isMinimized = true;
    }
}
