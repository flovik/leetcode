namespace Sandbox.Solutions.Medium;

public class FindAllPossibleRecipesFromGivenSupplies
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        // looks like topological sort, represent everything as a node with an indegree into something
        // when we have some indegree false, we add that node for processing and if in degree for that current node is 0, then
        // we add it to processing

        var resultList = new List<string>(recipes.Length);
        var recipesSet = new HashSet<string>(recipes);
        var map = new Dictionary<string, HashSet<string>>(recipes.Length);
        var inDegree = new Dictionary<string, int>();

        for (var i = 0; i < recipes.Length; i++)
        {
            var recipe = recipes[i];
            var recipeIngredients = ingredients[i];

            inDegree.TryAdd(recipe, 0);

            foreach (var ingredient in recipeIngredients)
            {
                map.TryAdd(ingredient, []);
                map[ingredient].Add(recipe);

                inDegree[recipe]++;
                inDegree.TryAdd(ingredient, 0);
            }
        }

        var pq = new PriorityQueue<string, int>();

        foreach (var supply in supplies)
        {
            if (!inDegree.TryGetValue(supply, out var count))
                continue;

            if (count == 0)
                pq.Enqueue(supply, 1);
        }

        while (pq.Count > 0)
        {
            var deq = pq.Dequeue();

            if (!map.TryGetValue(deq, out var recipeIngredients))
                continue;

            foreach (var recipeIngredient in recipeIngredients)
            {
                inDegree[recipeIngredient]--;

                if (inDegree[recipeIngredient] == 0)
                {
                    if (recipesSet.Contains(recipeIngredient))
                        resultList.Add(recipeIngredient);

                    pq.Enqueue(recipeIngredient, 1);
                }
            }
        }

        return resultList;
    }
}