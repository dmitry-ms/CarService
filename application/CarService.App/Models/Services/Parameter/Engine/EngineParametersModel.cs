using System.Collections.Generic;

namespace CarService.App.Models
{
    public class EngineParametersModel
    {
        public virtual IEnumerable<string> EngineNames { get; set; } = new List<string>();
    }
}
