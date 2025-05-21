using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
public class SpellingGameManager : MonoBehaviour
{
    public GameObject letterButtonsPanel;
    public GameObject wordDisplayPanel;

    public GameObject letterButtonPrefab;
    public GameObject letterSlotPrefab;

    public TMP_Text feedbackText;
    public GameObject endPanel;
    public float waitTime = 1.5f;
    public List<string> wordList = new List<string> { "SUN", "DOG", "TREE", "BOOK" };
    private string targetWord;
    private char[] filledSlots;
    private bool[] slotFilled;

    IEnumerator  Start()
    {
        yield return new WaitForSeconds(waitTime);
        StartNewRound();
    }

    void StartNewRound()
    {
        feedbackText.text = "";
        SelectRandomWord();
        CreateLetterSlots();
        CreateLetterButtons();
    }

    void SelectRandomWord()
    {
        targetWord = wordList[Random.Range(0, wordList.Count)].ToUpper();
        filledSlots = new char[targetWord.Length];
        slotFilled = new bool[targetWord.Length];
    }

    void CreateLetterSlots()
    {
        foreach (Transform child in wordDisplayPanel.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < targetWord.Length; i++)
        {
            GameObject slot = Instantiate(letterSlotPrefab, wordDisplayPanel.transform);
            slot.GetComponentInChildren<TMP_Text>().text = "_";
        }
    }

    void CreateLetterButtons()
    {
        foreach (Transform child in letterButtonsPanel.transform)
            Destroy(child.gameObject);

        HashSet<char> letterSet = new HashSet<char>(targetWord);
        while (letterSet.Count < 5)
        {
            char c = (char)Random.Range(65, 91); // A–Z
            letterSet.Add(c);
        }

        List<char> shuffled = new List<char>(letterSet);
        for (int i = 0; i < shuffled.Count; i++)
        {
            int rand = Random.Range(i, shuffled.Count);
            (shuffled[i], shuffled[rand]) = (shuffled[rand], shuffled[i]);
        }
        foreach (char c in shuffled)
        {
            GameObject btn = Instantiate(letterButtonPrefab, letterButtonsPanel.transform);
            btn.GetComponent<LetterButton>().SetLetter(c.ToString());
        }

    }

    public void OnLetterTapped(string letter)
    {
        bool placed = false;

        for (int i = 0; i < targetWord.Length; i++)
        {
            if (!slotFilled[i] && targetWord[i].ToString() == letter)
            {
                Transform slot = wordDisplayPanel.transform.GetChild(i);
                slot.GetComponentInChildren<TMP_Text>().text = letter;

                filledSlots[i] = letter[0];
                slotFilled[i] = true;
                placed = true;          
            }
        }

        if (placed && IsWordComplete())
        {
            endPanel.SetActive(true);
            feedbackText.text = "Correct!";
        }
    }
    bool IsWordComplete()
    {
        foreach (bool filled in slotFilled)
            if (!filled) return false;
        return true;
    }
}
