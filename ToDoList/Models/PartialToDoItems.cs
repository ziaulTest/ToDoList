using Newtonsoft.Json;

namespace ToDoList.Models
{
    public class PartialToDoItems
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Task")]
        public string Task { get; set; }
        [JsonProperty(PropertyName = "Priority")]
        public string Priority { get; set; }

    }
}
