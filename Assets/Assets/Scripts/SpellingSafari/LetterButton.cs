using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LetterButton : MonoBehaviour
{
    public string letter;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            FindObjectOfType<SpellingGameManager>().OnLetterTapped(letter);
        });
    }

    public void SetLetter(string l)
    {
        letter = l;
        GetComponentInChildren<TMPro.TMP_Text>().text = l;
        Debug.Log("this wrk well");
     
    }
}
