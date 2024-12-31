using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    [SerializeField] Transform head;
    public GameObject bloodyScreen;
    public TextMeshProUGUI PlayerhealthUI;
    public GameObject gameOverUI;
    public bool isDead;

    private void Start()
    {
        PlayerhealthUI.text = $"Health: {health}";
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            if (!isDead)
            {
                print("Player dead");
                PlayerDead();
            }
            isDead = true;
                
        }
        else
        {
            print("Player Hit");
            StartCoroutine(BloodyScreenEffect());
            PlayerhealthUI.text = $"Health: {health}";
            SoundManager.instance.playerChannel.PlayOneShot(SoundManager.instance.playerHurt);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand")) 
        {
            TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
            print("Hit by zombie");
         }
           
        
    }


    private IEnumerator BloodyScreenEffect()
    {
        if (bloodyScreen.activeInHierarchy == false)
        {
            bloodyScreen.SetActive(true);
        }

        var image = bloodyScreen.GetComponentInChildren<Image>();

        // Set the initial alpha value to 1 (fully visible).
        Color startColor = image.color;
        startColor.a = 1f;
        image.color = startColor;

        float duration = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the new alpha value using Lerp.
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // Update the color with the new alpha value.
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;

            yield return null; ; // Wait for the next frame.
        }

        if (bloodyScreen.activeInHierarchy)
        {
            bloodyScreen.SetActive(false);
        }
    }

    private void PlayerDead()
    {
        SoundManager.instance.playerChannel.PlayOneShot(SoundManager.instance.playerDie);

        GetComponentInChildren<Animator>().enabled = true;
        PlayerhealthUI.gameObject.SetActive(false);
        GetComponent<ScreenFader>().StartFade();
        StartCoroutine(ShowGameOverUI());
        SceneManager.LoadScene("DeadScene");

    }
    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }
   
}