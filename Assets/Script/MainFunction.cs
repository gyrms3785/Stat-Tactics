using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFunction : MonoBehaviour
{
    public GameObject parentCha;

    void Start() //playerpref로 데이터를 다 불러오고 전투 시작
    {
        Fight();
    }

    public void Fight() //Time.deltaTime으로 굴러가게 하는게 제일 좋은듯
    {
        double gameTime = parentCha.transform.GetChild(7).GetComponent<MonsterHp>().element[3];
        double[] relativeTime = new double[8];
        double[] playerturn = new double[8];

        for(int i=0; i<relativeTime.Length-1; i++)
        {
            relativeTime[i] = (parentCha.transform.GetChild(i).GetComponent<ChaStatus>().statList[3])/gameTime;
        }
        relativeTime[7] = 1;

        while(parentCha.transform.GetChild(7).GetComponent<MonsterHp>().element[0] > 0)
        {
            for(int i=0; i<playerturn.Length; i++)
            {
                playerturn[i] += relativeTime[i];

                if(playerturn[i] > 100 && (i!=7))
                {
                    float elapsedTime = 0.0f;

                    while(elapsedTime < 2f)
                    {
                        elapsedTime += (Time.deltaTime);
                    }

                    StartCoroutine(playerAttack(i));
                }

                /*else if(playerturn[i] > 100)
                {
                    monsterAttack();
                }*/
            }
        }
    }

    IEnumerator playerAttack(int Character)
    {
        double[] Chastat = parentCha.transform.GetChild(Character).GetComponent<ChaStatus>().statList;
        double[] Monstat = parentCha.transform.GetChild(7).GetComponent<MonsterHp>().element;

        Debug.Log("7");
        
        if(Monstat[2] >= Chastat[1])
        {
            Monstat[0] -= 1;
        }

        else
        {
            Monstat[0] -= 2;
        }

        yield return null;

        Debug.Log(Monstat[0]);
    }

    public void monsterAttack()
    {
        //parentCha.transform.GetChild(7).
    }
}
