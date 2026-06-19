using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestAPITest.DTO
{
    public class BetDTO
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public int? RoundNumber { get; set; }
        public BoxDTO? Box1 { get; set; }
        public BoxDTO? Box2 { get; set; }
    }

    public class BoxDTO
    {
        public string? LessParity { get; set; }
        public List<int>? LessNumbers { get; set; }
        public int? Result { get; set; }
    }
}
