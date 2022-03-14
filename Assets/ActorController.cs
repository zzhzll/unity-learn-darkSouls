using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject model;
    public PlayerInput playerInput;

    [SerializeField]
    private Animator anim;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // print(playerInput.Dup);
        anim.SetFloat("forward", playerInput.Dmag);
        model.transform.forward = playerInput.Dvec;
    }
}
