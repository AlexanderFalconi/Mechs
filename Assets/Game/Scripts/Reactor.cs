using UnityEngine;
using System.Collections.Generic;

public class Reactor : Component 
{
	private float Energy;
	private static Dictionary<string,Dictionary<float,float>> ReactorTable = new Dictionary<string,Dictionary<float,float>>() 
	{
		{"m6 fusion", new Dictionary<float,float>() {{0.0f, 25.0f}}}, {"m11 fusion", new Dictionary<float,float>() {{0.0f, 23.0f}}}, 
		{"m157 fusion", new Dictionary<float,float>() {{0.0f, 21.0f}}}, {"fission", new Dictionary<float,float>() {{0.0f, 15.0f}}}, 
		{"combustion", new Dictionary<float,float>() {{0.0f, 3.0f}}}, {"solar", new Dictionary<float,float>() {{0.0f, 1.0f}}}
	};

	public static void Setup () 
	{
		Dictionary<string,float> increases = new Dictionary<string,float>() {{"m6 fusion",1.0f}, {"m11 fusion",1.0f}, {"m157 fusion",1.0f}, {"fission",1.0f}, {"combustion",1.0f}, {"solar",1.0f}};
		Dictionary<string,float> bases = new Dictionary<string,float>() {{"m6 fusion",25.0f}, {"m11 fusion",23.0f}, {"m157 fusion",21.0f}, {"fission",15.0f}, {"combustion",3.0f}, {"solar",1.0f}};
		for(float i = 0.5f; i <= 35.0f; i+=0.5f)
		{
			foreach(string type in ReactorTable.Keys)
			{
				increases[type] *= 0.95f;
				ReactorTable[type][i] = ReactorTable[type][i-0.5f] + bases[type]*increases[type];
			}
		}
	}

	public Reactor(float mass, string type)
	{
		if(mass % 0.25f > 0.0f)
			Debug.LogError("Reactor mass must be in increments of 0.25.");
		SetMass(mass);
		Debug.Log(type);
		Energy = ReactorTable[type][mass];
	}
}
