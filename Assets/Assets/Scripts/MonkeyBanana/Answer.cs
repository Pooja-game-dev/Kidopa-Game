using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Answer : MonoBehaviour
{
    bool isAnswered = false;
    [SerializeField] GameObject nextPanel;
    [SerializeField] GameObject answerPanel;
    [SerializeField] GameObject numberPanel;
    [SerializeField] GameObject numberPanel2;


    public void PanelDisplay()
    {

       nextPanel.SetActive(true);
        //answerPanel.SetActive(false);
    }
    public void PanelHide()
    {

        numberPanel.SetActive(false);
        numberPanel2.SetActive(true);
        nextPanel.SetActive(false);
        numberPanel2.SetActive(true);
        isAnswered = true;

    }
    
    public void SubstractionAnswer(string sceneName)
    {
        if (isAnswered == true)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    

}
