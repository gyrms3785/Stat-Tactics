using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputStatUp : MonoBehaviour
{
    public TMP_Text StatInput;
    public TMP_Text StatCount;
    public int i;

    private void OnMouseDown() {
        if(int.Parse(GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text) - int.Parse(StatInput.text.Substring(0,StatInput.text.Length-1)) >= 0)
        {
            GameObject Cha = GameObject.Find("StatusBlock").GetComponent<ChoiceCha>().Character;
            Cha.GetComponent<ChaStatus>().statList[i] += int.Parse(StatInput.text.Substring(0,StatInput.text.Length-1));
            StatCount.text = Cha.GetComponent<ChaStatus>().statList[i].ToString();

            int temp = int.Parse(GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text) - int.Parse(StatInput.text.Substring(0,StatInput.text.Length-1));
            GameObject.Find("RemainStat").GetComponent<TextMeshProUGUI>().text = temp.ToString();
        }
    }
}