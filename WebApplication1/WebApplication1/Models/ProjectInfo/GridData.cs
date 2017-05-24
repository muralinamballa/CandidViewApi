using System.Collections.Generic;
using Newtonsoft.Json;

namespace CandidView.Models.ProjectInfo
{
    public class GridData
    {
        [JsonProperty(PropertyName = "columns")]
        List<Column> Columns { get; set; }
        [JsonProperty(PropertyName = "rows")]
        List<Row> Rows { get; set; }
    }
}
