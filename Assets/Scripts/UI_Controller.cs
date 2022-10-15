using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject circle;
    public GameObject generator;
    public GameObject restartDialoge;

    private bool _isDie;
    private int _coinCount;
    private int _playerCoinCount;

    public GameObject win;
    public GameObject lose;
    private InteractionScript script;


    void Start()
    {
        _coinCount = generator.GetComponent<GeneratorScript>()._coinCount;
        script = circle.GetComponent<InteractionScript>();
    }

    void Update()
    {

        _isDie = script.isDie;
     
        if (_isDie)
        {
            restartDialoge.SetActive(true);
            lose.SetActive(true);
        }

        _playerCoinCount = script.coins_count;

        if (_playerCoinCount == _coinCount)
        {
            restartDialoge.SetActive(true);
            win.SetActive(true);
            
        }
     
    }
    public void ResrartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
