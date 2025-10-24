using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Scripture
{
    private List<Word> _listOfWords;

    public List<Word> GetList() // getter
    {
        return _listOfWords;
    }

    public Scripture(List<Word> scripture) // constructor
    {
        _listOfWords = scripture;
    }

    public List<int> RandomGenerator(List<Word> scripture)
    {
        Random random = new();
        List<int> listOfNumbers = [];

        int length = scripture.Count;

        for (int i = 0; i < length; i++)
        {
            bool inList = true;
            int number = random.Next(0, length);
            while (inList == true)
            {
                if (listOfNumbers.Contains(number))
                {
                    inList = true;
                    number = random.Next(0, length);
                }
                else
                {
                    inList = false;
                }
            }
            listOfNumbers.Add(number);
        }
        return listOfNumbers;
    }

    public void Display(List<Word> _listofWords)
    {
        foreach (Word i in _listofWords)
        {
            i.Display();
        }
    }

    public void Menu(Reference scriptureRef)
    {
        string input = "";
        int index = 0;
        int wordsHidden = 0;

        List<Word> scripture = GetList();
        int scriptureLength = scripture.Count;
        Display(scripture);

        List<int> listOfNumbers = RandomGenerator(scripture);
        int length = listOfNumbers.Count;
        int r = length % 2;

        while (input != "quit")
        {
            Console.WriteLine("\n\nPress enter or type 'quit' to finish");
            input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }
            Console.Clear();
            index = Hide(scripture, listOfNumbers, index);
            index = Hide(scripture, listOfNumbers, index);
            scriptureRef.Display();
            Display(scripture);
            wordsHidden += 2;
            if (r == 1 && wordsHidden == (length - 1))
            {
                Console.WriteLine("\n\nPress enter or type 'quit' to finish");
                input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                index = Hide(scripture, listOfNumbers, index);
                input = "quit";
            }
            else if (wordsHidden == length)
            {
                input = "quit";
            }
        }
    }


    public int Hide(List<Word> scripture, List<int> listOfNumbers, int index)
    {
        int hiddenScripture = listOfNumbers[index];
        scripture[hiddenScripture].SetHidden();
        index += 1;
        return index;
    }
}