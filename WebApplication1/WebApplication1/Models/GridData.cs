using Newtonsoft.Json;

namespace CandidView.models
{
    public class GridData
    {
        [JsonProperty(PropertyName = "columns")]
        Column[] Columns { get; set; }
        [JsonProperty(PropertyName = "rows")]
        Row[] Rows { get; set; }
    }
}
