using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyRegApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LazyRegApp.Pages
{
    public class IndexModel : PageModel
    {
        private IEnumerable<Lazy<ISomeLazyTransient>> _someLazyThings;
        private IEnumerable<Lazy<IExpensiveService>> _someExpensiveServices;
        private IEnumerable<LazyWithMetaData<IExpensiveService, MyMetaData>> _someExpensiveServicesWithMetaData;
        private IEnumerable<ISomeTransient> _someThings;
        private ILogger<IndexModel> _logger;
        private Lazy<ISomeTransientZero> _lazySomeTransientZero;

        public IndexModel(
            ILogger<IndexModel> logger,
            Lazy<ISomeTransientZero> lazySomeTransientZero,
            IEnumerable<ISomeTransient> someThings,
            IEnumerable<Lazy<ISomeLazyTransient>> someLazyThings,
            IEnumerable<Lazy<IExpensiveService>> someExpensiveServices,
             IEnumerable<LazyWithMetaData<IExpensiveService, MyMetaData>> someExpensiveServicesWithMetaData
            )
        {
            _logger = logger;
            _lazySomeTransientZero = lazySomeTransientZero;
            _someThings = someThings;           // All constructors for these have fired
            _someLazyThings = someLazyThings;   // just the Lazy containers are there
            _someExpensiveServices = someExpensiveServices;
            _someExpensiveServicesWithMetaData = someExpensiveServicesWithMetaData;
        }
        public async void OnGet()
        {
            _logger.LogDebug($"OnGet() Enter");
            // Ever object in the _someThings enumerable has had their constructors fired.
            var countSomeThings = _someThings.Count();

            // All the Lazy containers have been instantiated, but what they contain has not.
            // the .Value is only going to get instantiated when we ask for it.
            var countSomeLazyThings = _someLazyThings.Count(); // still no constructors fired

            // so we know how many Lazy containers the IEnumerable contains, and be assured that the inner values
            // are still not in play
            List<string> names = new List<string>();

            var isCreated = _lazySomeTransientZero.IsValueCreated;  // false,good...
            var someTransientZero = _lazySomeTransientZero.Value;   // constructor fired, good...
            isCreated = _lazySomeTransientZero.IsValueCreated;      // true,good...

            names.Add(someTransientZero.Name);

            foreach (var lazyObject in _someLazyThings)
            {
                isCreated = lazyObject.IsValueCreated; // false, good...
                names.Add(lazyObject.Value.Name); // as expected, the Lazy container kicks in and fires the constructor
                isCreated = lazyObject.IsValueCreated; // true, good...
            }

            foreach (var someThing in _someThings)
            {
                names.Add(someThing.Name);  // normal objects here.
            }

            var expensiveCount = _someExpensiveServices.Count();
            foreach (var lazyObject in _someExpensiveServices)
            {
                var resolvedService = lazyObject.Value;
                var value = await resolvedService.GetDataAsync();
                names.Add(value); // as expected, the Lazy container kicks in and fires the constructor

            }

            var _someExpensiveServicesWithMetaDataCount = _someExpensiveServicesWithMetaData.Count();
            foreach (var lazyObject in _someExpensiveServicesWithMetaData)
            {
                var metaData = lazyObject.MetaData;
                var resolvedService = lazyObject.Value;
                var value = await resolvedService.GetDataAsync();
                names.Add(value); // as expected, the Lazy container kicks in and fires the constructor
            }


            _logger.LogDebug($"OnGet() Exit");

        }
    }
}
