using UnityEngine;
using System.Collections.Generic;

public class Bushwacker : Mech 
{
	public Bushwacker() : base()
	{
		Short = "Bushwacker";
		Long = "A Bushwacker mech.";
		Body["center torso"].Attach(this);
		Body["left torso"].Attach(Body["center torso"], this);//Connect limb
		Body["right torso"].Attach(Body["center torso"], this);
		Body["head"].Attach(Body["center torso"], this);
		Body["left arm"].Attach(Body["left torso"], this);
		Body["right arm"].Attach(Body["right torso"], this);
		Body["left leg"].Attach(Body["left torso"], this);
		Body["right leg"].Attach(Body["right torso"], this);
		//Chassis configuration
		SetMass(30.0f, new TitaniumBipedalMech());//Set Mass and Structure
		AddComponent("center torso", new M6Fusion(2.5f));//Add engine
		AddComponent("left leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("right leg", new M1LegActuator(1.0f));//Add actuators
		AddComponent("left leg", new M1FootActuator(0.75f));//Add actuators
		AddComponent("right leg", new M1FootActuator(0.75f));//Add actuators
		AddComponent("left leg", new M1HipActuator(0.75f));//Add actuators
		AddComponent("right leg", new M1HipActuator(0.75f));//Add actuators
		AddComponent("left arm", new M1ArmActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1ArmActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1HandActuator(0.25f));//Add actuators
		AddComponent("left arm", new M1ShoulderActuator(0.25f));//Add actuators
		AddComponent("right arm", new M1ShoulderActuator(0.25f));//Add actuators
		AddComponent("head", new CompactCockpit());//Add cockpit
		AddComponent("center torso", new M2Central());//Add gyros
		AddComponent("left leg", new X1Impulse());//Add thrusters
		AddComponent("right leg", new X1Impulse());//Add thrusters
		AddComponent("left arm", new TC5());//Add weapons
		AddComponent("left arm", new CC5Shell());//Add weapons
		AddComponent("right arm", new TC5());//Add weapons
		AddComponent("right arm", new CC5Shell());//Add weapons
		AddComponent("left torso", new SRM6());//Add weapons
		AddComponent("left torso", new Arrow2Missile());//Add ammo
		AddComponent("left torso", new Arrow2Missile());//Add ammo
		AddComponent("right torso", new SL375());//Add weapons
		AddComponent("right torso", new MMG20());//Add weapons
		AddComponent("right torso", new Bullets762());//Add ammo
		AddArmor("center torso", "external", new Steel(0.25f));//Add armor
		AddArmor("center torso", "rear", new Steel(0.25f));//Add armor
		AddArmor("left torso", "external", new Steel(0.75f));//Add armor
		AddArmor("left torso", "rear", new Steel(0.25f));//Add armor
		AddArmor("right torso", "external", new Steel(0.75f));//Add armor
		AddArmor("right torso", "rear", new Steel(0.25f));//Add armor
		AddArmor("left arm", "external", new Steel(0.5f));//Add armor
		AddArmor("right arm", "external", new Steel(0.5f));//Add armor
		AddArmor("left leg", "external", new Steel(0.5f));//Add armor
		AddArmor("right leg", "external", new Steel(0.5f));//Add armor
		AddArmor("head", "external", new Steel(0.25f));//Add armor
	}
}
