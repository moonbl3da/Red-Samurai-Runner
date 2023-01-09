using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    public TextMeshProUGUI swordScoreUI;
    public TextMeshProUGUI distanceScoreUI;
    public int swordsScore;
    public int distanceScore;

    bool addDis = false;
    private void Update()
    {
        swordScoreUI.text = swordsScore.ToString();

        if(addDis == false)
        {
            addDis = true;
            StartCoroutine(AddDistance());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Sword"))
        {
            swordsScore++;
        }    
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Golem") && swordsScore >= 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("Golem"));
            swordsScore -= 3;
        }else if(other.gameObject.CompareTag("Golem") && swordsScore < 3){
            GameManager.isGameOver = true;
        }
    }
    IEnumerator AddDistance()
    {
        distanceScore += 1;
        distanceScoreUI.text = "Score: " + distanceScore.ToString();
        yield return new WaitForSeconds(0.25f);
        addDis = false;
    }
}
