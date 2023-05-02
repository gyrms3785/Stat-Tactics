using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusOff : MonoBehaviour
{
    public GameObject Option;
    public GameObject MainCamera;
    public GameObject MoveCamera;
    public GameObject SubCamera;

    private void OnMouseDown() {
        for(int i=0; i<GameObject.Find("Status").transform.childCount; i++)
        {
            GameObject.Find("Status").transform.GetChild(i).transform.GetChild(3).GetComponent<TMP_InputField>().text = "";
        }

        SubCamera.transform.position = new Vector3 (20,0,-10);
        MoveCamera.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        SubCamera.gameObject.SetActive(false);
        StartCoroutine(lerpCoroutine(MoveCamera.transform.position
            ,new Vector3(0,0,-10), 0.1f
            ,MoveCamera.GetComponent<Camera>().orthographicSize));
    }
  
    IEnumerator lerpCoroutine(Vector3 current, Vector3 target, float time, float size)
    {
        float elapsedTime = 0.0f;

        MoveCamera.transform.position = current;
        while(elapsedTime < time)
        {
            elapsedTime += (Time.deltaTime);

            MoveCamera.transform.position = Vector3.Lerp(current, target, elapsedTime / time);
            MoveCamera.GetComponent<Camera>().orthographicSize =  size + (elapsedTime / time)*(5-size);

            yield return null;
        }
        Option.gameObject.SetActive(true);

        MoveCamera.transform.position = target;
        MoveCamera.GetComponent<Camera>().orthographicSize = 5;

        yield return new WaitForSecondsRealtime(0.1f);

        MainCamera.gameObject.SetActive(true);
        MoveCamera.gameObject.SetActive(false);
    }
}
