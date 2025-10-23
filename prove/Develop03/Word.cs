using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;

class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word) // constructor
    {
        _word = word;
        _hidden = false;
    }

    public void SetHidden() // setter 
    {
        _hidden = true;
    }

    public bool IsHidden() // getter
    {
        return _hidden;
    }

    public void Display()
    {
        bool hidden = this.IsHidden();
        if (hidden == false)
        {
            Console.Write($"{this._word} ");
        }
        else
        {
            int length = this._word.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
    }
}