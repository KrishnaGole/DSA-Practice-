// See https://aka.ms/new-console-template for more information\
using LeetCodeDesignDSAQuestions;

internal class Program
{
    static void Main(string[] args)
    {
        FoodRatings foodRatings = new FoodRatings(new string[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" },
            new string[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" },
            new int[] { 9, 12, 8, 15, 14, 7 });
        Console.WriteLine(foodRatings.HighestRated("korean"));
        Console.WriteLine(foodRatings.HighestRated("japanese"));
        foodRatings.ChangeRating("sushi", 16);
        Console.WriteLine(foodRatings.HighestRated("japanese"));
        foodRatings.ChangeRating("ramen", 16);
        Console.WriteLine(foodRatings.HighestRated("japanese"));


    }
}

