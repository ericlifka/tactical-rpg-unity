using System;

public class Coord {
	public int x;
	public int y;

	public Coord() {
		this.x = 0;
		this.y = 0;
	}
	public Coord(int x, int y) {
		this.x = x;
		this.y = y;
	}
	public bool equal(Coord other) {
		return x == other.x && y == other.y;
	}
}
