using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCalculator : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public GameObject[] faceDetectors;
    public MeshRenderer meshRenderer;
    public bool hasLanded = false;
    public AudioSource soundLit;
    public AudioSource soundCollideFloor;
    public AudioSource soundCollideDice;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;

    }

    private void SetInitialize()
    {
        int x = Random.Range(0, 360);
        int y = Random.Range(0, 360);
        int z = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(z, x, y);

        x = Random.Range(0, 25);
        y = Random.Range(0, 25);
        z = Random.Range(0, 25);
        Vector3 force = new Vector3(x, -y, z);

        x = Random.Range(0, 50);
        y = Random.Range(0, 50);
        z = Random.Range(0, 50);
        Vector3 torque = new Vector3(x, y, z);

        transform.rotation = rotation;
        rb.velocity = force;

        this.rb.maxAngularVelocity = 1000;
        rb.AddTorque(torque, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.freezeRotation = false;
            SetInitialize();

        }    

        if(CheckIfObjectHasStopped() == true)
        {
            int indexResult = FindFaceResult();
        
            if(hasLanded == false)
            {
                soundLit.Play();
                hasLanded = true;
            }
        }

        //ChangeTextureToLit(IndexResult);
    }

    /*
    private void ChangeTextureToLit(int faceResults)
    {
        switch (faceResults)
        {
            case 0: //Beast
                meshRenderer.materials[1].mainTexture = texturelitList(faceResults);
            break;
        }
    }
    */

    public int FindFaceResult()
    {
        int maxIndex = 0;
        for (int i = 1; i < faceDetectors.Length; i++)
        {
            if (faceDetectors[maxIndex].transform.position.y < faceDetectors[i].transform.position.y)
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public bool CheckIfObjectHasStopped()
    {
        if(rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero)
        {
            return true;
        }
        else return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Dice"))
        {
            PlaySoundCollideDice();
        }

        if (collision.transform.CompareTag("Floor"))
        {
            PlaySoundCollideFloor();
        }
    }

    public void PlaySoundCollideFloor()
    {
        if(!soundCollideFloor.isPlaying)
            soundCollideFloor.Play();
    }

    public void PlaySoundCollideDice()
    {
        if (!soundCollideDice.isPlaying)
            soundCollideDice.Play();
    }
}
