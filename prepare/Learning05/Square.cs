namespace Learning05;

class Square(int sideLength, string color) : Shape(color) {

    private readonly int side = sideLength;
    
    public override double GetArea() {
        return side * side;
    }

}