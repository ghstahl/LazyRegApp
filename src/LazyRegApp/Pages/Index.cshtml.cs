using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LazyRegApp.Pages
{
    public class IndexModel : PageModel
    {
        private IEnumerable<Lazy<ISomeLazyTransient>> _someLazyThings;
        private IEnumerable<ISomeTransient> _someThings;
        private Lazy<ISomeTransientZero> _lazySomeTransientZero;

        public IndexModel(
            Lazy<ISomeTransientZero> lazySomeTransientZero,
            IEnumerable<ISomeTransient> someThings,
            IEnumerable<Lazy<ISomeLazyTransient>> someLazyThings)
        {
            _lazySomeTransientZero = lazySomeTransientZero;
            _someThings = someThings;           // All constructors for these have fired
            _someLazyThings = someLazyThings;   // just the Lazy containers are there
        }
        public void OnGet()
        {
            List<string> names = new List<string>();

            var isCreated = _lazySomeTransientZero.IsValueCreated; // false,good...
            var someTransientZero = _lazySomeTransientZero.Value;  // constructor fired, good...
            names.Add(someTransientZero.Name);

            var countSomeThings = _someThings.Count();
            var countSomeLazyThings = _someLazyThings.Count(); // still no constructors fired
            foreach (var lazyObject in _someLazyThings)
            {
                isCreated = lazyObject.IsValueCreated; // false, good...
                names.Add(lazyObject.Value.Name); // as expected, the Lazy container kicks in and fires the constructor
            }
            foreach (var someThing in _someThings)
            {
                names.Add(someThing.Name);  // normal objects here.
            }
        }
    }
}
