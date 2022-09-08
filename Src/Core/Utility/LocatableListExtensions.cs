using EPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public static class LocatableListExtensions
    {
        public static bool DoSearch( this IEnumerable<ILocatable> list, string searchKey, out IEnumerable<ILocatable> foundSuggested )
        {
            searchKey = searchKey.Trim();
            var suggestionsList = new List<ILocatable>();
            var foundExact = false;


            if(FindExact(searchKey, list, out var match))
            {
                suggestionsList.Add(match);
                foundExact = true;
            }
            else
            {
                suggestionsList.Concat(FindSimilar(searchKey, list));
            }

            foundSuggested = suggestionsList;
            return foundExact;
        }

        private static bool FindExact(string searchKey, IEnumerable<ILocatable> list, out ILocatable found)
        {
            var exactMatches = list.Where(e => string.Equals(e.ReadableName, searchKey, StringComparison.OrdinalIgnoreCase));

            if(exactMatches.Count() == 1)
            {
                found = exactMatches.First();
                return true;
            }

            found = null;
            return false;
        }

        private static IEnumerable<ILocatable> FindSimilar(string searchKey, IEnumerable<ILocatable> list)
        {
            var suggestions = new List<ILocatable>();
            var keyWords = searchKey.Split(' ', StringSplitOptions.TrimEntries);
            var suggestedNames = new HashSet<string>();

            bool SearchFunc( ILocatable e, string key )
            {
                if(suggestedNames.Contains(e.ReadableName))
                {
                    return false;
                }
                else if(e.ReadableName.Contains(key))
                {
                    suggestedNames.Add(e.ReadableName);
                    return true;
                }

                return false;
            }


            foreach(var key in keyWords)
            {
                suggestions.Concat(list.Where(e => SearchFunc(e, key)));
            }

            return suggestions;
        }
    }
}
