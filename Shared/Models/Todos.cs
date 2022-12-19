using Amazon.DynamoDBv2.DataModel;

namespace Learner.Shared.Models
{
    [DynamoDBTable("todos")]
    public class Todos
    {
        [DynamoDBHashKey("id")]
        public int? Id { get; set; }

        [DynamoDBProperty("poster_id")]
        public int PosterId { get; set; }

        [DynamoDBProperty("title")]
        public string? Title { get; set; }

        [DynamoDBProperty("description")]
        public string? Description { get; set; }

        [DynamoDBProperty("created_date")]
        public string? CreatedDate { get; set; }

        [DynamoDBProperty("is_completed")]
        public bool IsCompleted { get; set; }

    }
}