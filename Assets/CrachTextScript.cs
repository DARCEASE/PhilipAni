using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrachTextScript : MonoBehaviour
{
    public string[] words;
    public TextMeshProUGUI wordText;
    public float posTimer, colTimer, posSpd, colSpd;
    public bool isCrash;
    public Vector3 startPos, endPos;
    public Color startCol, endCol;

    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            //isCrash = true;
         
        }

        isCrash = player.gothit;

        if(isCrash)
        {
         
            CrashFunction();
            }
        */

        if (isCrash)
        {

            CrashFunction();
        }
    }

    public void SetText()
    {
        isCrash = true;
        wordText.text = words[Random.Range(0, 4)];
        posTimer = 0;
        colTimer = 0;
        wordText.GetComponent<RectTransform>().anchoredPosition = startPos;
        wordText.GetComponent<TextMeshProUGUI>().color = startCol;

    }

    public void CrashFunction()
    {
        posTimer += Time.deltaTime;
        wordText.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos, endPos, posTimer/posSpd);
        if(posTimer > .3f)
        {
            colTimer += Time.deltaTime;
            wordText.GetComponent<TextMeshProUGUI>().color = Color.Lerp(startCol, endCol, colTimer/colSpd);
        }
    }
}
