using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public void ChangeScene(string Scene)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(Scene);
#pragma warning restore CS0618 // Type or member is obsolete
    }
    private bool cred;
   

    // Use this for initialization
    void Start()
    {
        cred = true;

    }

    //Update is called once per frame
    void Update()
    {
        Debug.Log(Application.loadedLevelName);
        if ((Input.touchCount > 2) && (cred=true) && (Application.loadedLevelName != "Cred"))
        {
            cred = false;
            Application.LoadLevel("Cred");
            
        }
    }
}
