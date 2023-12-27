using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesignDSAQuestions
{
    public class FoodRatings
    {
        private Dictionary<string, int> foodRatingMap = new Dictionary<string, int>();
        private Dictionary<string, string> foodCuisineMap = new Dictionary<string, string>();
        private Dictionary<string, SortedSet<Tuple<int, string>>> cuisineFoodMap = new Dictionary<string, SortedSet<Tuple<int, string>>>();

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            for (int i = 0; i < foods.Length; ++i)
            {
                foodRatingMap[foods[i]] = ratings[i];
                foodCuisineMap[foods[i]] = cuisines[i];

                if (!cuisineFoodMap.ContainsKey(cuisines[i]))
                {
                    cuisineFoodMap[cuisines[i]] = new SortedSet<Tuple<int, string>>(new TupleComparer());
                }

                cuisineFoodMap[cuisines[i]].Add(Tuple.Create(-ratings[i], foods[i]));
            }
        }

        public void ChangeRating(string food, int newRating)
        {
            string cuisineName = foodCuisineMap[food];
            SortedSet<Tuple<int, string>> cuisineSet = cuisineFoodMap[cuisineName];

            cuisineSet.Remove(Tuple.Create(-foodRatingMap[food], food));
            foodRatingMap[food] = newRating;
            cuisineSet.Add(Tuple.Create(-newRating, food));
        }

        public string HighestRated(string cuisine)
        {
            int.min
            Tuple<int, string> highestRated = cuisineFoodMap[cuisine].FirstOrDefault();
            return highestRated != null ? highestRated.Item2 : null;
        }
    }

    // Comparer for Tuple<int, string>
    public class TupleComparer : IComparer<Tuple<int, string>>
    {
        public int Compare(Tuple<int, string> x, Tuple<int, string> y)
        {
            int compareByRating = x.Item1.CompareTo(y.Item1);
            if (compareByRating == 0)
            {
                return x.Item2.CompareTo(y.Item2);
            }
            return compareByRating;
        }
    }
    /**
     * Your FoodRatings object will be instantiated and called as such:
     * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
     * obj.ChangeRating(food,newRating);
     * string param_2 = obj.HighestRated(cuisine);
     */
}

