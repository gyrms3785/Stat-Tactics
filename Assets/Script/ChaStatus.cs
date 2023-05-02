using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChaStatus : MonoBehaviour
{
    public GameObject Option;
    public GameObject MainCamera;
    public GameObject MoveCamera;
    public GameObject SubCamera;
    public double[] statList;
    public int hihi; //추가해보자

    private void OnMouseDown() {
        Option.gameObject.SetActive(false);
        MoveCamera.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        SubCamera.gameObject.SetActive(false);
        SubCamera.transform.position = new Vector3 (20,0,-10);

        StartCoroutine(lerpCoroutine(MoveCamera.transform.position
            ,new Vector3(transform.position.x+(float)2.24, transform.position.y+(float)0.18, -10), 0.1f
            ,MoveCamera.GetComponent<Camera>().orthographicSize));

        GameObject.Find("StatusBlock").GetComponent<ChoiceCha>().Character = this.gameObject;

        for(int i=0; i<GameObject.Find("Status").transform.childCount; i++)
        {
            GameObject.Find("Status").transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = statList[i].ToString();
        }
    }
  
    IEnumerator lerpCoroutine(Vector3 current, Vector3 target, float time, float size)
    {
        float elapsedTime = 0.0f;

        MoveCamera.transform.position = current;
        while(elapsedTime < time)
        {
            elapsedTime += (Time.deltaTime);

            MoveCamera.transform.position = Vector3.Lerp(current, target, elapsedTime / time);
            MoveCamera.GetComponent<Camera>().orthographicSize =  size - (elapsedTime/time)*(size-2);

            yield return null;
        }
        MoveCamera.transform.position = target;
        MoveCamera.GetComponent<Camera>().orthographicSize = 2;

        yield return new WaitForSecondsRealtime(0.1f);

        SubCamera.transform.position = new Vector3(transform.position.x+(float)2.24, transform.position.y+(float)0.18, -10);
        SubCamera.gameObject.SetActive(true);
        GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0;
        GameObject.Find("Status").transform.position = new Vector3(GameObject.Find("Status").transform.position.x
        , 0, GameObject.Find("Status").transform.position.z);
        MoveCamera.gameObject.SetActive(false);
    }
}
