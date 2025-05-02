using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovableNPCs : MonoBehaviour {
    //General AI
    private NavMeshAgent Npc;
    public GameObject sprite;

    [Header("Raycasting and Patrolling")]
    public List<Vector3> Rays;
    public float distance;    
    public LayerMask layer;
    private int PointIteration;    

    public string IdleAnimName, MoveAnimName, AttackAnimName;
    public PlayerHealthScript PlayerHealth;

    public QuestGiverNPC questscript;
    private Vector3 NewDestination;
    private bool CanMove;
    public float WalkDistance;
    private float timer;
    private float timerWait;
    [Header("Eye Objects")]
    private GameObject PlayerEyesCollisionBox;
    private GameObject Horroreyes;
    private bool HasHorrorEyes;
    
    [Header("Other")]
    private Vector3 randLocation;
    private NavMeshHit NavHit;
   
    public List<Transform> PatrolPoints;
    private Transform CurrentPoint;
    private float timer2 = 0;
    private GameObject playerLocation;
    private GameObject PlayerCam;
    public Vector3 StartingLocationForPlayer;      
    public Animator CharacterAnimator;
    public Collider bone;
    public GameObject dogbowl;
    private int AttackType;
    private bool canAttack, canPatrol, canWalk;
    
    public GameObject Player, arrowGoal;
    private bool canraycast;

    private void Awake() {
        //ADDED BY JACOB
        dogbowl = GameObject.Find("dogbowl asset");        
    }

    // Start is called before the first frame update
    void Start() {
        canraycast  = true;
        canPatrol = true;
        canWalk = true;
        
        Npc = gameObject.GetComponent<NavMeshAgent>();
        
        PlayerEyesCollisionBox = GameObject.FindGameObjectWithTag("PlayerEyesCollisionBox");
        Horroreyes = GameObject.FindGameObjectWithTag("ScaryEyes");
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
        playerLocation = GameObject.FindGameObjectWithTag("Player");
        CanMove = true;
        timer = 0;
        timerWait = Random.Range(2, 7);
        
        StartingLocationForPlayer = GameObject.Find("Level1PlayerSpawn").transform.position;
        canAttack = true;
    }
    private void HorrorEyes() {               
        HasHorrorEyes = true;
        AttackType = 2;
    }
    private void NotHorrorEyes() {        
        HasHorrorEyes = false;
        AttackType = 1;
    }
    private void Tags() {
        //tags for enemy types
        if (transform.CompareTag("Human")) {
            if (HasHorrorEyes == true) {
                if (InvisibleAbility.FindObjectOfType<InvisibleAbility>().isInVisible == false) {
                    RayDirection();
                }
                if (canWalk == true) {
                    RandomLocation();
                }                
            }
            if (HasHorrorEyes == false) {
                if (canWalk == true) {
                    RandomLocation();
                }                
            }            
        }
        if (transform.CompareTag("Dog")) {
            CharacterAnimator.SetBool(MoveAnimName, true);
            bone = questscript.QuestBone;
            if (Vector3.Distance(Player.transform.position, transform.position) <= 1 && HasHorrorEyes == false) {               
                    if (bone != null && bone.transform.IsChildOf(playerLocation.transform) == true) {
                        bone.transform.SetParent(gameObject.transform);                        
                        //should stop the dog                        
                        canraycast = false;
                    }                
            }
            //stop dog
            if (bone != null && bone.transform.IsChildOf(gameObject.transform) == true) {
                Npc.speed = 0;
                CharacterAnimator.SetBool(MoveAnimName, false);

                //ADDED BY JACOB
                GameObject playerAnchor = GameObject.Find("PlayerAnchor");
                playerAnchor.GetComponent<SpawnLevel>().level1Obj.transform.GetChild(0).gameObject.SetActive(true);

                bone.transform.position = new Vector3(0, 0, 0);
                if (dogbowl != null) {
                    Npc.SetDestination(dogbowl.transform.position);
                }
                    Debug.Log(NewDestination);
                canraycast = false;
            }
           if (canraycast == true || HasHorrorEyes == true) { 
            RayDirection();
           }
            if (canPatrol == true) {
                Patrolling();
            }
            
        }
            
    }
    void RayDirection() {
        foreach (Vector3 ray in Rays) {
            //creates raycasts for each vector position in Rays list 
            RaycastHit hit = new RaycastHit();
            Vector3 angle = Quaternion.Euler(ray.x, ray.y, ray.z) * Vector3.forward;
            Debug.DrawRay(transform.position, transform.TransformDirection(angle) * distance, Color.red);
            if (Physics.Raycast(transform.position, transform.TransformDirection(angle), out hit, distance, layer)) {
                if (hit.collider.CompareTag("Player") && canAttack == true) {
                    canPatrol = false;
                    canWalk = false;                    
                    if (hit.distance > 1) {
                        //go to player destination
                        Npc.SetDestination(hit.collider.transform.position);
                        transform.LookAt(hit.transform.position);
                        CharacterAnimator.SetBool(MoveAnimName, true);
                        Npc.speed = 3.5f;
                    }
                    if (hit.distance <= 1 && canAttack == true) {   
                        //if in range and can attack do an attack type
                        if (AttackType == 1) {
                            Player.transform.position = StartingLocationForPlayer;
                            canAttack = false;                            
                        }
                        if (AttackType == 2) {
                            Npc.speed = 0;                            
                            if (canAttack == true) {
                                PlayerHealth.LoseHealth();
                                canAttack = false;                                
                            }                           
                        }
                    }             
                }
            }            
        }
    }
    //attack cooldown
    private void Attackwait() {        
        timer2 += Time.deltaTime;
        if (canAttack == false) {
            if (AttackType == 1) {
                if (timer2 >= 5) {
                    canAttack = true;
                    timer2 = 0;
                }
            }
            if (AttackType == 2) {
                if (timer2 >= 2) {
                    canAttack = true;
                    timer2 = 0;
                }
            }
        }
    }
    //patrols points and sets destination to them
    void Patrolling() {
        foreach (Transform point in PatrolPoints) {
            if (point == PatrolPoints[PointIteration]) {
                if (transform.position != point.transform.position) {
                    Npc.SetDestination(point.transform.position);                   
                }
                CurrentPoint = point;
                //if distance smaller or equal to 1 then go to next point
                if (Vector3.Distance(transform.position, CurrentPoint.position) <= 1) {
                    timer += Time.deltaTime;
                    float rand = Random.Range(2, 7);
                    if (timer >= rand) {
                        PointIteration += 1;
                        timer = 0;
                    }
                }
            }
        }
        if (PointIteration >= PatrolPoints.Count) {
            PointIteration = 0;            
        }
    }
    private void RandomLocation() {
        //find random location
        if (CanMove == true) {
            if (NavMesh.SamplePosition(randLocation, out NavHit, 20f, NavMesh.AllAreas)) {
                NewDestination = NavHit.position;
                CanMove = false;
            }
        }
        if (CanMove == false) {
            if (timer >= 2) {
                CanMove = true;
                Debug.Log(CanMove);
                timer = 0;
                timerWait = Random.Range(2, 7);
            }
        }
        Npc.SetDestination(NewDestination);
    }
    void Update() {
        Tags();       
        timer += Time.deltaTime;
        randLocation = transform.position + Random.insideUnitSphere * WalkDistance;
        //if player has horror eyes
        if (Horroreyes.transform.IsChildOf(PlayerEyesCollisionBox.transform)) {
            HorrorEyes();
        }
        else {
            NotHorrorEyes();
        }    
        //make sprite look at player
        sprite.transform.LookAt(PlayerCam.transform.position);
        if (bone == null) {
        }
        if (canAttack == false) {
            canPatrol = true;
            canWalk = true;
               
            Attackwait();
        }        
    }
}