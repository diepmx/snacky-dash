using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DrawIfAttribute : PropertyAttribute
{
	public enum DisablingType
	{
		ReadOnly = 2,
		DontDraw = 3,
		DrawIfNot = 4
	}

	public string comparedPropertyName { get; private set; }

	public object comparedValue { get; private set; }

	public DisablingType disablingType { get; private set; }

	public DrawIfAttribute(string comparedPropertyName, object comparedValue, DisablingType disablingType = DisablingType.DontDraw)
	{
	}
}
