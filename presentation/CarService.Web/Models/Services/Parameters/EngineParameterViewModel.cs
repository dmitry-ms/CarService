using System.Collections.Generic;

namespace CarService.Web.Models
{
    public class EngineParameterViewModel
    {
        public IEnumerable<string> EngineNames { get; set; } = new List<string>();
    }
}
