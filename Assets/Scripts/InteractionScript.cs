using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public int coins_count=0;
    public Text coinsText;

    public bool isDie = false;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coins_count++;
            coinsText.text = "Coins:" + coins_count;
        }
        if (collider.gameObject.CompareTag("Spike"))
        {
            animator.Play("burst");
            isDie = true;
        }
    }

}
