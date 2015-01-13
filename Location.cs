using UnityEngine;
using System.Collections;
using System;

public class Location : MonoBehaviour {

	private double x;
	private double y;

	public Location(double inX, double inY)
	{
		x = inX;
		y = inY;
	}

	
	public double getX()
	{
		return x;
	}
	
	public double getY()
	{
		return y;
	}

	public static double getDistanceBetween(Location a, Location b)
	{
		return System.Math.Sqrt(System.Math.Pow(b.x - a.x, 2.0f) + System.Math.Pow(b.y - a.y, 2.0f));
	}

	public static Location calculateNextLocation(Location start, Location end,
	                                             double speed)
	{
		Location unitVector = calculateUnitVector(start, end);
		Location nextLocation = new Location(start.x + unitVector.x * speed,
		                                     start.y + unitVector.y * speed);
		return nextLocation;
	}

	private static Location calculateUnitVector(Location start, Location end)
	{
		double distance = getDistanceBetween(start, end);
		Location vector = new Location(end.x - start.x, end.y - start.y);
		vector.x /= distance;
		vector.y /= distance;
		
		return vector;
	}

}
