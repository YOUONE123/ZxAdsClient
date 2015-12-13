using UnityEngine;
using System.Collections;

public class UIViewController : MonoBehaviour {

    public string title;

    UIViewController currentView;

    public void SetUI(UIViewController ui)
    {
        this.title = ui.title;
        if(currentView != null) this.currentView.gameObject.SetActive(false);
        this.currentView = ui;
        this.currentView.gameObject.SetActive(true);
    }
}
