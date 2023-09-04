using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    public void OpenURL(string URLName)
    {
        Application.OpenURL(URLName);
    }
}
