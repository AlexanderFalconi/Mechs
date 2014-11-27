using UnityEngine;
using System.Collections.Generic;

public class Hellfyre : Mech 
{
	public Hellfyre()
	{
		//Connect limb
		Body["center torso"].Attach(this);
		Body["left torso"].Attach(Body["center torso"], this);
		Body["right torso"].Attach(Body["center torso"], this);
		Body["head"].Attach(Body["center torso"], this);
		Body["left arm"].Attach(Body["left torso"], this);
		Body["right arm"].Attach(Body["right torso"], this);
		Body["left leg"].Attach(Body["left torso"], this);
		Body["right leg"].Attach(Body["right torso"], this);
		//Chassis configuration
		SetMass(50.0f, new TitaniumBipedalMech());//Set Mass and Structure
		AddComponent("center torso", new M6Fusion(15.0f));//Add engine
		AddComponent("left leg", new M1LegActuator(1.5f));//Add actuators
		AddComponent("right leg", new M1LegActuator(1.5f));//Add actuators
		AddComponent("left leg", new M1FootActuator(1.0f));//Add actuators
		AddComponent("right leg", new M1FootActuator(1.0f));//Add actuators
		AddComponent("left leg", new M1HipActuator(1.0f));//Add actuators
		AddComponent("right leg", new M1HipActuator(1.0f));//Add actuators
		AddComponent("left arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("right arm", new M1ArmActuator(0.5f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1ShoulderActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1ShoulderActuator(0.25f));//Add actuators
		AddComponent("head", new StandardCockpit());//Add cockpit
		AddComponent("head", new LifeSupport());//Add life support
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("left leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("left arm", new TC15());//Add weapons
		AddComponent("left arm", new CC15Shell());//Add ammo
		AddComponent("left arm", new LL1());//Add weapons
		AddComponent("left arm", new LRM10());//Add weapons
		AddComponent("left arm", new Arrow1Missile());//Add ammo
		AddComponent("right arm", new TC15());//Add weapons
		AddComponent("right arm", new CC15Shell());//Add ammo
		AddComponent("right arm", new HMG1());//Add weapons
		AddComponent("right arm", new Cal50Bullet());//Add ammo
		AddArmor("center torso", "external", new Steel(1.0f));//Add armor
		AddArmor("center torso", "rear", new Steel(1.0f));//Add armor
		AddArmor("left torso", "external", new Steel(1.0f));//Add armor
		AddArmor("left torso", "rear", new Steel(1.0f));//Add armor
		AddArmor("right torso", "external", new Steel(1.0f));//Add armor
		AddArmor("right torso", "rear", new Steel(1.0f));//Add armor
		AddArmor("left arm", "external", new Steel(1.0f));//Add armor
		AddArmor("right arm", "external", new Steel(1.0f));//Add armor
		AddArmor("left leg", "external", new Steel(1.0f));//Add armor
		AddArmor("right leg", "external", new Steel(1.0f));//Add armor
		AddArmor("head", "external", new Steel(1.0f));//Add armor
	}
}
