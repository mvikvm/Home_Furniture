Disigner disigner = new Disigner();
Director director = new Director();

Controller mediator = new Controller(disigner, director);

director.GiveCommand("Проектировать");
Console.WriteLine();
disigner.ExecuteWork();

interface IMediator
{
    void Notify(Employee emp, string msg);
}

abstract class Employee
{
    protected IMediator mediator;
    public Employee(IMediator mediator) => this.mediator = mediator;
    public void SetMediator (IMediator med) => this.mediator = med;
}

class Disigner : Employee
{
    private bool isWorking;
    public Disigner(IMediator med = null) : base(med) { }
    public void ExecuteWork()
    {
        Console.WriteLine("--Дизайнер в работе");
        mediator.Notify(this, "дизайнер проектирует...");
    }
    public void SetWork(bool state)
    {
        isWorking = state;
        if (state)
            Console.WriteLine("--Дизайнер освобожден от работы");
        else
            Console.WriteLine("--Дизайнер занят");
    }
}

class Director : Employee
{
    private string text;
    public Director (IMediator mediator = null) : base(mediator) { } 
    public void GiveCommand (string txt)
    {
        text = txt;
        if (text == "")
            Console.WriteLine("--Директор знает, что дизайнер уже работает");
        else
            Console.WriteLine("--Директор дал команду : " +  text);
        mediator.Notify(this, text);
    }
}

class Controller : IMediator
{
    private Disigner disigner;
    private Director director;
    public Controller (Disigner disigner, Director director)
    {
        this.disigner = disigner;
        this.director = director;
        disigner.SetMediator(this);
        director.SetMediator(this);
    }
    public void Notify (Employee emp, string msg)
    {
        if (emp is Director dir)
        {
            if (msg == "")
                disigner.SetWork(false);
            else
                disigner.SetWork(true);
        }
        if (emp is Disigner des)
        {
            if (msg == "дизайнер проектирует...")
                director.GiveCommand("");
        }
    }
}


