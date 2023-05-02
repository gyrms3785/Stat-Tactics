using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScroll : MonoBehaviour
{
    public Scrollbar StatScrollbar;
    public GameObject SubCamera;

    public void ScrollChange() {
        float CameraPositionY = SubCamera.transform.position.y;
        float scrollValue = StatScrollbar.GetComponent<Scrollbar>().value;
        GameObject.Find("Status").transform.position = new Vector3(GameObject.Find("Status").transform.position.x
        , scrollValue*6*0.4f+CameraPositionY, GameObject.Find("Status").transform.position.z);
    }
}