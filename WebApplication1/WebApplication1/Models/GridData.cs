using System.Collections.Generic;
using Newtonsoft.Json;

namespace CandidView.models
{
    public class GridData
    {
        [JsonProperty(PropertyName = "columns")]
        List<Column> Columns { get; set; }
        [JsonProperty(PropertyName = "rows")]
        List<Row> Rows { get; set; }
    }
}
