namespace Learning05;

abstract class Shape(string color) {

    public string Color {get; private set;} = color;


    public abstract double GetArea();

}