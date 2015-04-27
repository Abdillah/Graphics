using System;
using System.Text.RegularExpressions;


public class Matrix
{
	public int x,y,z;
	
	public Translation(int tx, int ty, int tz)      // Calculation for translate a point
    {
        x = x + tx;
		y = y + ty;
		z = z + tz;
    }
	
	public Scaling(int sx, int sy, int sz)			//Calculation for scale a point
	{
		x = x*sx;
		y = y*sy;
		z = z*sz;
	}
	
	public Rotate_x(int betha)
	{
		x = x;
		y = (y*cos(betha)) - (z*sin(betha));
		z = (y*sin(betha)) + (z*cos(betha));
	}
	
	public Rotate_y(int betha)
	{
		x = (x*cos(betha)) + (z*sin(betha));
		y = y;
		z = (-x*sin(betha)) + (z*cos(betha));
	}
	
	public Rotate_z(int betha)
	{
		x = (x*cos(betha)) - (y*sin(betha));
		y = (x*sin(betha)) + (y*cos(betha));
		z = z;
	}
	
	public Shearing(int shx, int shy)
	{
		x = x + (shx*z);
		y = y + (shy*z);
		z = z;
	}
}