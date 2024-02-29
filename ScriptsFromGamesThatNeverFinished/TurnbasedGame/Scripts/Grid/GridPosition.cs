

using System;
public struct GridPosition : IEquatable<GridPosition>
{
    //this is our struct, that will replace "vector2"
    //change this into eqivalent of "vector3"  // vector3 would work well here

    public int x;
    public int y;
    public int z;

    public GridPosition(int x, int y, int z)  //helper-function
    {
        //add int y above
        this.x = x;
        this.y = y;
        this.z = z;
    }


    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
        x == position.x &&
        y == position.y &&
        z == position.z;
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, z);
        //add y above
    }

    public override string ToString()
    {
        return "x: " + x + "; y: " + y + "; z: " + z;
        //add "y: " + y // above
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
        //add a.y == b.y && //above
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

}