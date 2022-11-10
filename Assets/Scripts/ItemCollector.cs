using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int melons;

    [SerializeField] private TextMeshProUGUI melonsText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            melons++;
            melonsText.text = melons.ToString();
        }
    }
}
