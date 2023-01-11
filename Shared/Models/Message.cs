using Amazon.DynamoDBv2.DataModel;

namespace Learner.Shared.Models
{
    [DynamoDBTable("messages")]
    public class Message
    {
        [DynamoDBHashKey("id")]
        public int? Id { get; set; }

        [DynamoDBProperty("chat_id")]
        public int? ChatId { get; set; }

        [DynamoDBProperty("poster_name")]
        public string PosterName { get; set; }

        [DynamoDBProperty("content")]
        public string? Content { get; set; }

        [DynamoDBProperty("created_date")]
        public string? CreatedDate { get; set; }

    }
}