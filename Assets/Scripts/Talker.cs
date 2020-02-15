using UnityEngine;

public class Talker : MonoBehaviour
{
    public string[] Texts;
    public GameObject thatgo;
    public bool ConversationStarter;

    private float wait = 0f;
    private bool talking = false;
    private bool mluvimJa = true;
    private Conversation con;
    private Talker that;
    private float distance = 2.0f;

    void Start()
    {
        that = thatgo.GetComponent<Talker>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (ConversationStarter)
            {
                if (!talking)
                {
                    if (Vector2.Distance(transform.position, thatgo.transform.position) < distance)
                    {
                        this.StartTalking(new Conversation(Texts));
                    }
                }
                else
                    Talk(con);
            }
        }
        if (ConversationStarter)
        {
            if (talking && Vector2.Distance(transform.position, thatgo.transform.position) >= distance)
            {
                StopTalking();
            }
        }
    }

    public void Talk(Conversation con)
    {
        string say = con.Next();
        if (say == null)
            StopTalking();
        else
        {
            if (mluvimJa)
                Say(say);
            else
                that.Say(say);
            mluvimJa = !mluvimJa;
        }
    }

    public void StartTalking(Conversation con)
    {
        talking = true;
        that.Talking(true);
        this.con = con;
        Talk(con);
    }

    public void StopTalking()
    {
        talking = false;
        that.Talking(false);
        con = null;
        Debug.Log("Converastion stop");
    }

    public void Talking(bool t)
    {
        talking = t;
    }

    public void Say(string text)
    {
        Debug.Log(text);
    }
}
