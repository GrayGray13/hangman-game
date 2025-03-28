namespace HangmanApp;

public class Hangman
{
    private string? Word { get; set; }
    private readonly string[] _hangmanStates =
    [
        "+---+\n  |   |\n      |\n      |\n      |\n      |\n=========", 
        "+---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
        "+---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
        "+---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
        "+---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
        "+---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
        "+---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
    ];
    private int _hangmanStateIndex;
    private List<char> Guesses { get; }
    public bool GameActive { get; private set; }
    
        
    public Hangman(string? word)
    {
        this.Word = word;
        this._hangmanStateIndex = 0;
        this.Guesses = new List<char>();
        this.CreateGuesses();
        this.GameActive = true;
    }

    public void ShowHangman()
    {
        Console.WriteLine(_hangmanStates[this._hangmanStateIndex]);
    }

    private void CreateGuesses()
    {
        for (var i = 0; i < this.Word.Length; i++)
        {
            this.Guesses.Add('_');
        }
    }

    public void ShowGuesses()
    {
        Console.WriteLine(string.Join(" ", this.Guesses));
    }

    public void Guess(char guessedLetter)
    {
        if (this.Guesses.Contains(guessedLetter))
        {
            Console.WriteLine("You already guessed this letter correctly, try another letter.");
        } 
        else if (!this.Word.Contains(guessedLetter))
        {
            if (this._hangmanStateIndex < 5)
            {
                this._hangmanStateIndex++;
                Console.WriteLine("Sorry, this letter is not in the word! Try another letter.");
            }
            else
            {
                this._hangmanStateIndex++;
                this.ShowHangman();
                Console.WriteLine("Game Over!");
                Console.WriteLine($"The word is: {this.Word}");
                this.GameActive = false;
            }
        }
        else
        {
            for (var i = 0; i < this.Word.Length; i++)
            {
                if (this.Word[i] == guessedLetter)
                {
                    this.Guesses[i] = guessedLetter;
                }
            }

            if (!this.Guesses.Contains('_'))
            {
                Console.WriteLine("You got the word and won!");
                this.GameActive = false;
            }
        }
    }
}