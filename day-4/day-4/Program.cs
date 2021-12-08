using day_4;

var processor = new InputProcessor();
var input = processor.GetInput("./input.txt");

var bingoRolls = processor.GetRollsFromInput(input);

var cards = processor.GetBingoCards(input);

var game = new Game(cards);

game.PlayGame(bingoRolls);

/////////////////////////////////////////////////////////
////////////////////////Part 1///////////////////////////
/////////////////////////////////////////////////////////

(BingoCard winningCard, int winningRoll) = game.Winner;

var winningSum = winningCard.GetUnmarkedSum();

var part_1 = winningRoll * winningSum;

Console.WriteLine($"Answer part 1: {part_1}");

/////////////////////////////////////////////////////////
////////////////////////Part 2///////////////////////////
/////////////////////////////////////////////////////////
(BingoCard losingCard, int losingRoll) = game.Loser;

var losingSum = losingCard.GetUnmarkedSum();

var part_2 = losingRoll * losingSum;

Console.WriteLine($"Answer part 2: {part_2}");

Console.ReadLine();