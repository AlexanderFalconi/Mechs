using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour 
{
	public Engine Environment;
	public int Size = 0;//1: infantry, 2: suit, 3: car, 4: tank, 5: light mech, 6: medium mech, 7: heavy mech, 8: small structure, 9: large structure, 10: tile
	public Vector3 Position, Facing;
	public Player Controller;
	public string Short, Long;

	public virtual void SetPosition(Vector3 pos, Vector3 face)
	{
		Position = pos;
		transform.position = pos;
		Facing = face;
	}

	public Entity BindController(Player who)
	{
		Controller = who;
		return this;
	}

	public virtual string GetEntityType()
	{
		return "entity";
	}

	public virtual void Update()
	{

	}
}