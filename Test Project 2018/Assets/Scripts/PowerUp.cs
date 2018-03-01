using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for every powerUp in the game
public class PowerUp : MonoBehaviour {

    //protected fields needed for every powerUp
    [SerializeField] protected float effectDuration;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected GameObject player;
    [SerializeField] protected float bonusMultiplier;
    [SerializeField] protected AudioSource effectAudio;
    protected PlayerController playerController;
    protected Animator effectAnimator;

    protected void Start () {

        playerController = player.GetComponent<PlayerController>();
        effectAnimator = GetComponent<Animator>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        //player should not use more than one power at any given time
        if ((other.gameObject.CompareTag("Player")) && !playerController.UsingPowerUp) 
        {
            StartCoroutine(TriggerEffect());
        }
    }

    //rotates powerup object every frame using Time.delta Time
    protected void Update () {

        transform.Rotate(new Vector3(0, 30, 0) * rotationSpeed * Time.deltaTime);
    }

    protected IEnumerator TriggerEffect()
    {
        playerController.UsingPowerUp = true;
        StartEffect();
        yield return new WaitForSeconds(effectDuration);
        EndEffect();
        playerController.UsingPowerUp = false;
        gameObject.SetActive(false);
    }

    //derived classes will implement their own effects
    protected virtual void StartEffect()
    {

    }

    //derived classes will implement their own effects
    protected virtual void EndEffect()
    {

    }

}
