using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Ghost[] ghosts;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text scorePacmanText;
    [SerializeField] private Text livesText;

    public int scorePacman { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private int ghostMultiplier = 1;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScorePacman(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        gameOverText.enabled = false;

        foreach (Transform pellet in pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "x" + lives.ToString();
    }

    private void SetScorePacman(int scorePacman)
    {
        this.scorePacman = scorePacman;
        scorePacmanText.text = scorePacman.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();

        SetLives(lives - 1);

        if (lives > 0) {
            Invoke(nameof(ResetState), 3f);
        } else {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * ghostMultiplier;
        SetScorePacman(scorePacman + points);

        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet, MonoBehaviour collector)
    {
        pellet.gameObject.SetActive(false);
        
        if (collector is Pacman)
        {
            SetScorePacman(scorePacman + pellet.points);
        }
        else if (collector is Ghost)
        {
            // Potentially add score for ghost collecting pellet
        }
     
        if (!HasRemainingPellets())
        {
            foreach (Transform pelletTransform in pellets)
            {
                pelletTransform.gameObject.SetActive(true);
            }
            //pacman.gameObject.SetActive(false);
            //Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet, MonoBehaviour collector)
    {
        pellet.gameObject.SetActive(false);
        
        if (collector is Pacman)
        {
            for (int i = 0; i < ghosts.Length; i++) 
            {
                ghosts[i].frightened.Enable(pellet.duration);
            }

        SetScorePacman(scorePacman + pellet.points);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        }
        else if (collector is Ghost)
        {
            // Potentially add score for ghost collecting power pellet
        }
        
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

}
