using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience Settings")]
    [SerializeField] AnimationCurve experienceCurve;
    
    int currentLevel, totalExperience;
    int previousLevelExperience, nextLevelExperience;

    [Header("Interface Elements")]  
    [SerializeField] private Text levelText;
    [SerializeField] private Text experienceText;
    [SerializeField] private Image experiencefill;

    void Start()
    {
        currentLevel = 1;
        totalExperience = 0;
        previousLevelExperience = 0;
        nextLevelExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateLevel();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            AddExperience(150);
        }
    }
    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelExperience)
        {
            currentLevel++;
            UpdateLevel(); 
        }
    }

    void UpdateLevel()
    {
        previousLevelExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelExperience;
        int end = nextLevelExperience - previousLevelExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + "exp / " + end + "exp";
        experiencefill.fillAmount = (float)start / end;
    }
}
