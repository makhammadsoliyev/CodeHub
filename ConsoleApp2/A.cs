namespace ConsoleApp2;

public class A
{
    public void M()
    {
        Console.WriteLine("A");
    }

    public void Call()
    {
        M();
    }
}

public class B : A
{
    public new void M()
    { Console.WriteLine("B"); }

}
