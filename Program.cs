using HangmanApp;

var randomWord = await RandomWord.GetRandomWord();
Console.WriteLine(randomWord);

var hangman = new Hangman(randomWord);

while (hangman.GameActive)
{
    hangman.ShowHangman();
    hangman.ShowGuesses();
    Console.Write("Enter a letter to guess the word: ");
    
    var input = Console.ReadLine();
    var guessedLetter = char.Parse(input ?? throw new InvalidOperationException());
    Console.Clear();
    hangman.Guess(guessedLetter);
}