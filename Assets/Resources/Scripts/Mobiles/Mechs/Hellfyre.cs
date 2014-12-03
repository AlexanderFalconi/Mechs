using UnityEngine;
using System.Collections.Generic;

public class Hellfyre : Mech 
{
	public Hellfyre() : base()
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
		SetMass(60.0f, new TitaniumBipedalMech());//Set Mass and Structure
		AddComponent("center torso", new M6Fusion(6.0f));//Add engine
		AddComponent("left leg", new M1LegActuator(2.5f));//Add actuators
		AddComponent("right leg", new M1LegActuator(2.5f));//Add actuators
		AddComponent("left leg", new M1FootActuator(1.25f));//Add actuators
		AddComponent("right leg", new M1FootActuator(1.25f));//Add actuators
		AddComponent("left leg", new M1HipActuator(1.25f));//Add actuators
		AddComponent("right leg", new M1HipActuator(1.25f));//Add actuators
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
		AddComponent("left leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("left arm", new TC10());//Add weapons
		AddComponent("left arm", new CC10Shell());//Add ammo
		AddComponent("left torso", new LRM10());//Add weapons
		AddComponent("left torso", new Arrow1Missile());//Add ammo
		AddComponent("right arm", new TC10());//Add weapons
		AddComponent("right arm", new CC10Shell());//Add ammo
		AddComponent("right torso", new ML24());//Add weapons
		AddComponent("right torso", new HMG1());//Add weapons
		AddComponent("right torso", new Cal50Bullet());//Add ammo
		AddArmor("center torso", "external", new Steel(1.25f));//Add armor
		AddArmor("center torso", "rear", new Steel(0.5f));//Add armor
		AddArmor("left torso", "external", new Steel(2.0f));//Add armor
		AddArmor("left torso", "rear", new Steel(0.75f));//Add armor
		AddArmor("right torso", "external", new Steel(2.0f));//Add armor
		AddArmor("right torso", "rear", new Steel(0.5f));//Add armor
		AddArmor("left arm", "external", new Steel(0.75f));//Add armor
		AddArmor("right arm", "external", new Steel(0.75f));//Add armor
		AddArmor("left leg", "external", new Steel(1.0f));//Add armor
		AddArmor("right leg", "external", new Steel(1.0f));//Add armor
		AddArmor("head", "external", new Steel(0.75f));//Add armor
	}
}
