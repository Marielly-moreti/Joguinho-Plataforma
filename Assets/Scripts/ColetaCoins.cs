using UnityEngine;

public class ColetaCoins : MonoBehaviour
{
    public int coinCount = 0;
    public TMPro.TextMeshProUGUI textoMoedas;
    int moedas = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
    
        if (collision.gameObject.name.Contains("Coin") == true)
        {
            Destroy(collision.gameObject);
            moedas++;
            textoMoedas.text = "Coins:  <color=yellow>" + moedas + "</color>";
        }   
    }
}
