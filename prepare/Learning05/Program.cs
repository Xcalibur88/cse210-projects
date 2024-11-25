using Learning05;

class Program {

    static void Main(string[] args) {
        List<Shape> shapes = [new Square(5, "Blue"), new Rectangle(5, 7, "Red"), new Circle(6, "Green")];

        foreach (Shape shape in shapes) {
            Console.WriteLine(shape.GetType());
            Console.WriteLine(shape.Color);
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }
        
    }

}