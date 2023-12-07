
/*Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
Пример лабиринта:
1 1 1 1 1 1 1
1 0 0 0 0 0 1
1 0 1 1 1 0 1
0 0 0 0 1 0 2
1 1 0 0 1 1 1
1 1 1 1 1 1 1
1 1 1 1 1 1 1
Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.*/

using System.Collections;
using System.Collections.Generic;

int[,] labirynth2 = new int[,]
    {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 1, 0, 0, 0, 0, 1 },
        {1, 1, 1, 1, 1, 0, 1 },
        {2, 0, 0, 0, 1, 0, 2 },
        {1, 1, 0, 2, 1, 1, 1 },
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 1, 1, 2, 1, 1, 1 }
};

Stack <Tuple<int, int>> _path = new Stack<Tuple<int, int>>();

int row = EnterValueInt(text: "Введите индекс строки -> ");
int column = EnterValueInt(text: "Введите индекс столбца -> ");

int count = FindPath(row,column, labirynth2);

Console.WriteLine($"Найдено путей - {count}");

int EnterValueInt(string text)
{
    Console.Write(text);
    int value = Convert.ToInt32(Console.ReadLine());

    return value;
}




int FindPath (int i, int j, int[,]someLabirint)
{
    int count = 0;

    if (someLabirint[i, j] == 0) _path.Push(new Tuple<int, int>(i, j));
    
    if (someLabirint[i, j] == 2) {
        count++;
        Console.WriteLine($"Путь найден. Его координаты - {i}:{j}");

    }
    

    while (_path.Count > 0)
    {
        

        var current = _path.Pop();

        // Console.WriteLine($"{current.Item1}:{current.Item2}");

        if (someLabirint[current.Item1, current.Item2] == 2)
        {
            Console.WriteLine($"Путь найден. Его координаты - {current.Item1}:{current.Item2}");
            count++;
        }

        someLabirint[current.Item1, current.Item2] = 1;

        if (current.Item1 + 1 < someLabirint.GetLength(0)
            && someLabirint[current.Item1 + 1, current.Item2] != 1)
            _path.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));
        
        if (current.Item2 + 1 < someLabirint.GetLength(1) 
            && someLabirint[current.Item1, current.Item2 + 1] != 1)
            _path.Push(new Tuple<int, int>(current.Item1, current.Item2+1));
        
        if ( current.Item1 > 0
            && someLabirint[current.Item1 - 1, current.Item2] != 1)
            _path.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));
        
        if (current.Item2 > 0
            && someLabirint[current.Item1, current.Item2 - 1] != 1)
            _path.Push(new Tuple<int, int>(current.Item1, current.Item2-1));
    }
    // Console.WriteLine("Путь не найден.");

    return count;

}


/*List<int> numbers = new List<int> { 1, 2,3 };

Console.WriteLine(string.Join(", ", numbers));

Console.WriteLine("-----");

Reverse(numbers);

Console.WriteLine(string.Join(", ", numbers));

foreach (var x in new CustomEnumerale())
{ 

    Console.WriteLine(x);

}



static void Reverse(List<int> inputList)
{
   
    var stack = new Stack<int>();

    for (int i = 0; i < inputList.Count; i++)
    {
        stack.Push(inputList[i]);
    }

    for (int i = 0;i < inputList.Count; i++)
    {
        inputList[i] = stack.Pop(); 
    }
}

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

public interface IEnumerator
{

    object Current { get; }
    bool MoveNext();
    void Reset();

}

internal class CustomEnumerator : IEnumerator<int>
{
    public int Current { get; private set; } = -1;

    object System.Collections.IEnumerator.Current => 0;

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        if (Current < 10)
        {

            Current++;
            return true;

        }

        return false;
        
    }

    public void Reset()
    {
        Current = -1;
    }
}

internal class CustomEnumerale : IEnumerable<int>
{
    
    public IEnumerator<int> GetEnumerator() => new CustomEnumerator();
    

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}*/





