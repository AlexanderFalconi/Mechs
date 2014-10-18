﻿using UnityEngine;
using System.Collections;

public class M11Fusion : Reactor {
	public string Short = "Mark-11 Fusion Reactor";
	public string Long = "A MechTech Mark-11 fusion reactor. It has been recently developed for more cutting-edge, light mechs.";
	public string[] Compatibility = new string[] {"left torso", "right torso", "center torso"};

	public M11Fusion(float mass): base(mass, "m11 fusion") 
	{

	}
}