//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Debug = UnityEngine.Debug;

//public class FootstepSounds : MonoBehaviour
//{
//    int count = 0;
//    bool isMoving = false;

//    [SerializeField]
//    AudioClip[] footStepClips;

//    [SerializeField]
//    AudioSource footStepSource;

//    public void PlayFootstep()
//    {
//        footStepSource.clip = footStepClips[0];
//        footStepSource.Play();
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        //if (other.gameObject.CompareTag("Background"))
//        //{
//        //    Debug.Log("CHECK");
//        //}
//        //if (other.gameObject.CompareTag("Highgrass"))
//        //{
//        //    Debug.Log("ME");
//        //}
//    }

//    void Update()
//    {
//        count++;
        
//        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
//        {
//            isMoving = true;
//        }
//    }



//    private void OnTriggerStay2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag("Background") && count >= 200 && isMoving)
//        {
//            footStepSource.clip = footStepClips[0];
//            StartCoroutine(Wait());
//            footStepSource.Play();
//            count = 0;
//        }
//        if (other.gameObject.CompareTag("Highgrass") && count >= 200 && isMoving)
//        {
//            footStepSource.clip = footStepClips[1];
//            StartCoroutine(Wait());
//            footStepSource.Play();
//            count = 0;
//        }
//    }

//    IEnumerator Wait()
//    {
//        yield return new WaitForSeconds(0.0f);
//    }

//}
