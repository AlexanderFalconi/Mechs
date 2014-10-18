using UnityEngine;
using System.Collections;

public class M157Fusion : Reactor {
	public string Short = "Mark-157 Fusion Reactor";
	public string Long = "A MechTech Mark-157 fusion reactor. It remains somewhat experimental, and its oversized design makes it appealing only to the lightest of mechs.";
	public string[] Compatibility = new string[] {"left torso", "right torso", "center torso"};

	public M157Fusion(float mass): base(mass, "m157 fusion") 
	{

	}
}
