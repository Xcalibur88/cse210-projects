namespace Learning05;

class Circle(int radius, string color) : Shape(color) {

    private readonly int radius = radius;
    
    public override double GetArea() {
        return Math.PI * Math.Pow(radius, 2);
    }

}