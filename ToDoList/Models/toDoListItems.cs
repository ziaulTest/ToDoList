
using Newtonsoft.Json;

namespace ToDoList.Models
{
    public class ToDoListItems
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Task")]
        public string Task { get; set; }
        [JsonProperty(PropertyName = "Priority")]
        public string Priority { get; set; }
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
    }
}