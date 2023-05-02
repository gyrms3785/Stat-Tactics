using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class StatUp : MonoBehaviour
{
    public TMP_Text StatCount;
    public int i;

    private void OnMouseDown() {
        if(int.Parse(GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text)-1 >= 0)
        {
            GameObject Cha = GameObject.Find("StatusBlock").GetComponent<ChoiceCha>().Character;
            Cha.GetComponent<ChaStatus>().statList[i] += 1;
            StatCount.text = Cha.GetComponent<ChaStatus>().statList[i].ToString();

            int temp = int.Parse(GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text) - 1;
            GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text = temp.ToString();
        }
    }
}
