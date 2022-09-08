namespace HW11;

delegate void Func(string str);

class MyClass
{


    public string Str { get; set; }
    public void Space(string str) => Console.WriteLine(string.Join('_', str.ToCharArray()));
    public void Reverse(string str)
    {
        char[] temp = str.ToCharArray();
        Array.Reverse(temp);
        string result = new(temp);
        Console.WriteLine(result);
    }

    public MyClass(string str)
    {
        Str = str;
    }

}

class Run
{
    public void RunFunc(Func del, string str)
    {
        foreach (var func in del.GetInvocationList())
            func.DynamicInvoke(str);
    }
}


class Program
{
    static void Main()
    {

        Console.WriteLine("Enter string");

        var str = Console.ReadLine();
        MyClass cls = new MyClass(str);

        Func funcDell = null!;
        funcDell += cls.Space;
        funcDell += cls.Reverse;


        Run run = new Run();
        run.RunFunc(funcDell, str);
    }
}
