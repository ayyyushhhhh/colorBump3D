using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
[SerializeField]private float thrust=100 ;
   Rigidbody PlayerRigidBody;
   private Vector2 lastmousepos;
   Scene scene;
   private float WallDistance=4.5f;
   [SerializeField]private float minCamDistance=3f;
private Admanager ad;
    // Start is called before the first frame update
    void Start()
    {  Time.timeScale=1f;
        PlayerRigidBody = GetComponent<Rigidbody>();
  ad= FindObjectOfType<Admanager>();
scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 Deltapos = Vector2.zero;
      if(Input.GetMouseButton(0))
      {Vector2 CurrentmousePos = Input.mousePosition;
        if(lastmousepos==Vector2.zero)
        lastmousepos=CurrentmousePos;
        Deltapos = CurrentmousePos - lastmousepos;
        lastmousepos = CurrentmousePos;

        Vector3 force = new Vector3(-Deltapos.y,0,Deltapos.x) * (thrust * Time.deltaTime);
        PlayerRigidBody.AddForce(force);

      }
else{
  lastmousepos = Vector2.zero;
    }
    }


      public void NextLevel()
      {

        SceneManager.LoadScene(scene.buildIndex+1);
        PlayerPrefs.SetInt("Level",scene.buildIndex);
        Debug.Log(PlayerPrefs.GetInt("Level"));
      }
      public void Restart()
      {
        Debug.Log("Die");
         scene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(scene.buildIndex);
      }
void OnCollisionEnter(Collision collision)
    {



    if(collision.gameObject.tag=="Enemy")
    {
      Debug.Log("Die");
      Restart();
    }
    if(collision.gameObject.tag=="Finish")
    {
      Rigidbody  rb = collision.gameObject.GetComponent<Rigidbody>();
                    rb.AddForce(this.transform.forward * 500);
      if(scene.buildIndex<10){
      NextLevel();
          Debug.Log("You Win");                       }
      else if(scene.buildIndex==10)
        {
            Debug.Log("AD");
              PlayerPrefs.SetInt("Level",0);
    ad.UserChoseToWatchAd();

        }
      }
    }
    void LateUpdate()
    {
      WallPositionCheck();
    }


    private void WallPositionCheck()
    {
    Vector3 pos = transform.position;
    if(transform.position.z>WallDistance)
    pos.z = WallDistance;
    if(transform.position.z<-WallDistance)
    pos.z = -WallDistance;

    transform.position = pos;

    }


    }
