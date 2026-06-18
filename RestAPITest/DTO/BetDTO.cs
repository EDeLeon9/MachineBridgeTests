using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestAPITest.DTO
{
    public class BetDTO
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public int? RoundNumber { get; set; }
        public Box? Box1 { get; set; }
        public Box? Box2 { get; set; }
    }

    public class Box
    {
        public string? LessParity { get; set; }
        public List<int>? LessNumbers { get; set; }
        public int? Result { get; set; }
    }
}
