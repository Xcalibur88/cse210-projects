namespace Learning05;

class Rectangle(int height, int width, string color) : Shape(color) {

    private readonly int height = height;
    private readonly int width = width;
    
    public override double GetArea() {
        return height * width;
    }

}