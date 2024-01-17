using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEPlayer : MonoBehaviour
{
    public TextMeshProUGUI TextBaseTMP;
    private List<char> LettersValid = new List<char>();
    public string TextBase;
    public int NumberLetter;
    [SerializeField] private int VerifLetters;
    
    private void Start()
    {
        LettersValid.AddRange(new char[] { 'A', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'W', 'X', 'C', 'V', 'B', 'N' });
        VerifLetters = 0;
    }
    
    public void Update()
    {
        char c = ' ';
        if (TextBase.Length > 0)
        {
            c = TextBase[VerifLetters];
        }
        char keyPressed = char.ToUpper(GetAnyKeyPressed());
        if (LettersValid.Contains(keyPressed))
        {
            if (c == keyPressed)
            {
                VerifLetters++;
                string correct = TextBase.Substring(0, VerifLetters);
                string otherPart = TextBase.Substring(VerifLetters, TextBase.Length - VerifLetters);

                //Debug.Log("CORRECT : " + correct);
                //Debug.Log("NEXT : " +otherPart );

                TextBaseTMP.text = $"<color=red>{correct}</color>{otherPart}"; ;
                if (VerifLetters == NumberLetter)
                {
                    VerifLetters = 0;
                    TextBaseTMP.gameObject.SetActive(false);
                }
            }
            else
            {
                TextBaseTMP.text = TextBase;
                VerifLetters = 0;
            }
        }
    }

    char GetAnyKeyPressed()
    {
        string inputString = Input.inputString;

        if (!string.IsNullOrEmpty(inputString))
        {
            return inputString[0];
        }

        // Aucune touche enfoncée
        return '\0';
    }
    // Créer le mot
    // Compter le nombre de lettre dans le mot -> NumberLetter

    // Variable int 0 VerifLetters
    // Verifier si la touche appuyée est égal au caractère d'index VerifLetters
        // Si oui changer sa couleur et incrémenter de 1 VerifLetters
            // Si VerifLetters est égal à NumberLetter
                // Le mot s'efface et la bombe explose
        // Si non mettre la couleur par défaut de toutes les lettres du mot et établir VerifLetters à 0
}
