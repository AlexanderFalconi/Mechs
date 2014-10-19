using UnityEngine;
using System.Collections.Generic;

public class Hellfyre : Mech 
{
	public Hellfyre () {
		foreach( string key in Limbs)
		{//Set up chassis dictionaries
			HitTable[key] = new Dictionary<string,int>();
			Proportion[key] = new Dictionary<string,float>() {{"max mass", 0.0f}, {"mass", 0.0f}};
			Components[key] = new List<Component>();
			Armors[key] = new Dictionary<string,Armor>() {{"internal", null}, {"external", null}, {"rear", null}};
		}
		//Chassis configuration
		HitTable["head"]["front"] = 1;
		HitTable["left arm"]["front"] = 5;
		HitTable["right arm"]["front"] = 5;
		HitTable["left leg"]["front"] = 4;
		HitTable["right leg"]["front"] = 4;
		HitTable["left torso"]["front"] = 5;
		HitTable["right torso"]["front"] = 5;
		HitTable["center torso"]["front"] = 7;
		HitTable["head"]["left"] = 1;
		HitTable["left arm"]["left"] = 9;
		HitTable["right arm"]["left"] = 3;
		HitTable["left leg"]["left"] = 5;
		HitTable["right leg"]["left"] = 2;
		HitTable["left torso"]["left"] = 7;
		HitTable["right torso"]["left"] = 4;
		HitTable["center torso"]["left"] = 5;
		HitTable["head"]["right"] = 1;
		HitTable["left arm"]["right"] = 3;
		HitTable["right arm"]["right"] = 9;
		HitTable["left leg"]["right"] = 2;
		HitTable["right leg"]["right"] = 5;
		HitTable["left torso"]["right"] = 4;
		HitTable["right torso"]["right"] = 7;
		HitTable["center torso"]["right"] = 5;
		HitTable["head"]["top"] = 6;
		HitTable["left arm"]["top"] = 6;
		HitTable["right arm"]["top"] = 6;
		HitTable["left leg"]["top"] = 0;
		HitTable["right leg"]["top"] = 0;
		HitTable["left torso"]["top"] = 6;
		HitTable["right torso"]["top"] = 6;
		HitTable["center torso"]["top"] = 6;
		HitTable["head"]["bottom"] = 0;
		HitTable["left arm"]["bottom"] = 0;
		HitTable["right arm"]["bottom"] = 0;
		HitTable["left leg"]["bottom"] = 18;
		HitTable["right leg"]["bottom"] = 18;
		HitTable["left torso"]["bottom"] = 0;
		HitTable["right torso"]["bottom"] = 0;
		HitTable["center torso"]["bottom"] = 0;
		Proportion["head"]["ratio"] = 0.03f;
		Proportion["left arm"]["ratio"] = 0.12f;
		Proportion["right arm"]["ratio"] = 0.12f;
		Proportion["left leg"]["ratio"] = 0.14f;
		Proportion["right leg"]["ratio"] = 0.14f;
		Proportion["left torso"]["ratio"] = 0.15f;
		Proportion["right torso"]["ratio"] = 0.15f;
		Proportion["center torso"]["ratio"] = 0.15f;
		SetMass(50.0f, new TitaniumBipedalMech());//Set Mass and Structure
		AddComponent("center torso", new M6Fusion(5.0f));//Add engine
		AddComponent("left leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("right leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("left leg", new M1FootActuator(0.25f));//Add actuators
		AddComponent("right leg", new M1FootActuator(0.25f));//Add actuators
		AddComponent("left leg", new M1HipActuator(0.25f));//Add actuators
		AddComponent("right leg", new M1HipActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("right arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("head", new StandardCockpit());//Add cockpit
		AddComponent("head", new LifeSupport());//Add life support
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("left leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("left arm", new TC5());//Add weapons
		AddComponent("right arm", new TC5());//Add weapons
		AddArmor("center torso", "external", 1.0f);//Add armor
		AddArmor("center torso", "rear", 1.0f);//Add armor
		AddArmor("left torso", "external", 1.0f);//Add armor
		AddArmor("left torso", "rear", 1.0f);//Add armor
		AddArmor("right torso", "external", 1.0f);//Add armor
		AddArmor("right torso", "rear", 1.0f);//Add armor
		AddArmor("left arm", "external", 1.0f);//Add armor
		AddArmor("right arm", "external", 1.0f);//Add armor
		AddArmor("left leg", "external", 1.0f);//Add armor
		AddArmor("right leg", "external", 1.0f);//Add armor
		AddArmor("head", "external", 1.0f);//Add armor
	}
}
