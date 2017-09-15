using UnityEngine;

public class CursorTex : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    //This is the different texture objects
    public Texture2D gameCursorTex;
    public Texture2D npcCursorTex;
    public Texture2D interactCursorTex;
    public Texture2D pickupCursorTex;
    public Texture2D enemyCursorTex;

    public CursorMode cursorMode = CursorMode.Auto; //Automatically sets the cursor mode

    public Vector2 hotSpot = Vector2.zero; //Provides an offset for the cursor

    NPCTalkTo talkToNPC;

    void Start()
    {
        talkToNPC = gameObject.GetComponent<NPCTalkTo>();
    }

    //This will happen everytime The mouse over object is not "Untagged", And change the cursor texture when the mouse is over an object
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag != "Untagged")
        {
            OnMouseEnter();
        }
        else
        {
            OnMouseExit();
        }
    }

    //This will set the cursor texture depending on the tag of the object
    void OnMouseEnter()
    {
        switch (hit.collider.tag)
        {
            case "Enemy":
                Cursor.SetCursor(enemyCursorTex, hotSpot, cursorMode);
                break;
            case "Pickup":
                Cursor.SetCursor(pickupCursorTex, hotSpot, cursorMode);
                break;
            case "Interactable":
                Cursor.SetCursor(interactCursorTex, hotSpot, cursorMode);
                break;
            case "Npc":
                Cursor.SetCursor(npcCursorTex, hotSpot, cursorMode);
                break;
        }
    }

    //This will set the cursor to the basic game cursor
    void OnMouseExit()
    {
        Cursor.SetCursor(gameCursorTex, Vector2.zero, cursorMode);
    }
}