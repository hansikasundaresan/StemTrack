using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Movement : MonoBehaviour  
{  
    public int count;
    public int startingLoad;
    public int forwardCount;
    public bool firstTranslate;
    public bool firstMovement;
    public bool finalExit;
    public bool secondTranslate;
    public bool secondMovement;
    public bool thirdTranslate;
    public bool thirdMovement;
    public AudioSource audioSource;
    public float volume=0.5f;
     
    // Start is called before the first frame update  
    void Start()  
    {  
        startingLoad = 0;
        count = 0;
        forwardCount =0;
        firstTranslate=true;
        firstMovement = false;
        secondTranslate= false;
        secondMovement = false;
        thirdTranslate = false;
        thirdMovement = false;
        finalExit= false;
        audioSource.PlayOneShot(audioSource.clip, volume);

    }  
  
    void moveforward( double val){
        this.transform.Translate(Vector3.forward * Time.deltaTime*(int)val);

    }
    void movebackward(double val){
        this.transform.Translate(Vector3.back * Time.deltaTime*(int)val);

    }
    void moveleftorRight(double val){
        transform.Translate((float)val, 0f, 0f); 

    }

    void moveDownorUp(double val){
        transform.Translate(0f, (float)val, 0f); 

    }

    // Update is called once per frame  
    void Update()  
    {  
        if(startingLoad <200){
            startingLoad++;
            return;
        }
        if(firstTranslate){
            //Debug.Log(count);
            if(count < 110){
                moveforward(135);
                moveleftorRight(-3.25);
            }
            else{
                //moveleftorRight(15);
                firstTranslate = false;
                startingLoad=0;
                secondTranslate=true;
                count = 0;
                forwardCount=0;



            }
            count++;
        }
        
        else if(secondTranslate){
            if(count < 160){
                movebackward(35);
                moveleftorRight(1.6);
            }
            else{
                /*if(forwardCount>110&& forwardCount<120){
                    moveDownorUp(2);
                }*/
                if(forwardCount < 120){
                    moveforward(55);
                    forwardCount++;
                }
                
                else{
                    secondTranslate=false;
                    thirdTranslate=true;
                    count = 0;
                    startingLoad=0;
                            forwardCount=0;
                }
            }
            count++;
        }

        else if(thirdTranslate){
            if(count < 160){
                movebackward(50);
                moveleftorRight(1.3);
            }
            else{
                /*if(forwardCount>110&& forwardCount<120){
                    moveDownorUp(2);
                }*/
                if(forwardCount < 120){
                    moveforward(55);
                    forwardCount++;
                }
                
                else{
                    thirdTranslate=false;
                    thirdMovement = true;
                    count = 0;
                    forwardCount=0;
                    startingLoad=0;
                }
            }
            count++;
        }
        

         else if(thirdMovement){
            if(count <400){
                moveleftorRight(0.2);
               // moveDownorUp(-0.025);
                moveforward(7);
            }
            else if(count < 1000){
                movebackward(15);
            }
            else if (count<1500){
                movebackward(20);
                moveleftorRight(-0.25);
            }
            
            else{
                thirdMovement=false;
                startingLoad=0;
                finalExit= true;
                count=0;
            }
            count++;
        }

        else if(finalExit){
            if(count<20){
            movebackward(20);
            moveleftorRight(-0.75);
            }
            else{
                finalExit= false;
            }
            count++;

        }



            

            
            /*
            this.transform.Translate(Vector3.back * Time.deltaTime);  
            this.transform.Rotate(Vector3.up, -10);  
            this.transform.Rotate(Vector3.up, 10);  
    */
    }  
}  