namespace TryOut._09Builder.Refactored.Classical;

public class BuilderExample {
    public BuilderExample() {
        var director = new Director();

        var car = director.Build<SportCarBuilder>();


    }
}
