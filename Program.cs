// See https://aka.ms/new-console-template for more information
// паттерн Шаблонный метод
// поведенческий паттерн
// можно использовать в случаях когда среди разных объектов
// существует схожее поведение, различающееся отдельными шагами
// (этапами) в алгоритме
Console.WriteLine("День Олега");
Oleg oleg = new Oleg();
oleg.LiveDay();
Console.WriteLine("День невезучего человека");
NotLucky notLucky = new NotLucky();
notLucky.LiveDay();

abstract class Human
{
    // шаблонный метод, который определяет алгоритм жизни 
    // абстрактного человека за один день
    public void LiveDay()
    { 
        if (!Awake())        
            return;
        GetBath();
        MorningEat();
        Work();
        Dinner();
        GetBath();
        Sleep();
    }

    // набор абстрактных и реализованных методов, которые можно
    // переопределить в классах-наследниках
    protected void Sleep()
    {
        Console.WriteLine("хррр...хррр...хррр...");
    }
    protected abstract void Dinner();
    protected abstract void Work();
    protected abstract void MorningEat();
    protected abstract void GetBath();
    protected abstract bool Awake();
}

//* Данный класс не имеет ввиду какого-либо конкретного Олега
// все совпадения абсолютно случайны
class Oleg : Human
{
    Random random = new Random();
    protected override bool Awake()
    {
        if (random.Next(0, 20) == 1)
        {
            Console.WriteLine("Критическая неудача. Проснуться не удалось.");
            return false;
        }
        return true;
    }

    protected override void GetBath()
    {
        if (random.Next(0, 20) == 1)
        {
            Console.WriteLine("Критическая неудача. В ванной с водой оказался включенный фен");
            return;
        }
        Console.WriteLine("Олег умылся и свеж как огурец");
    }

    protected override void MorningEat()
    {
        if (random.Next(0, 20) == 1)
        {
            Console.WriteLine("Критическая неудача. В холодильнике шаром покати, повесилась крыса и нет электричества");
            return;
        }
        Console.WriteLine("Утром Олег хорошо покушал");
    }

    protected override void Work()
    {
        if (random.Next(0, 20) == 1)
        {
            Console.WriteLine("Критическая неудача. Олег не работает и живет у мамы");
            return;
        }
        Console.WriteLine("Олег работает на заводе с 8:00 до 20:00");
    }

    protected override void Dinner()
    {
        if (random.Next(0, 20) == 1)
        {
            Console.WriteLine("Критическая неудача. Холодильник унесли тараканы");
            return;
        }
        Console.WriteLine("Вечером Олег хорошо покушал");
    }
}

class NotLucky : Human
{
    protected override bool Awake()
    {
        return true;
    }

    protected override void Dinner()
    {
        Console.WriteLine("Критическая неудача. Холодильник унесли тараканы");
    }

    protected override void GetBath()
    {
        Console.WriteLine("Критическая неудача. В ванной с водой оказался включенный фен");
    }

    protected override void MorningEat()
    {
        Console.WriteLine("Критическая неудача. В холодильнике шаром покати, повесилась крыса и нет электричества");
    }

    protected override void Work()
    {
        Console.WriteLine("Критическая неудача. Человек не работает и живет у мамы");
    }
}