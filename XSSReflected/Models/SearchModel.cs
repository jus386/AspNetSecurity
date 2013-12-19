using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using XSSReflected.Data;

namespace XSSReflected.Models
{
    public class SearchModel
    {
        [Display(Name = "Search")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter search")]
        public string SearchString { get; set; }

        public IEnumerable<Product> Results { get; set; }

        public int ResultsCount
        {
            get
            {
                if (Results == null)
                {
                    return 0;
                }
                return Results.Count();
            }
        }

        public SearchModel()
        {
            Results = new List<Product>();
        }
    }
}