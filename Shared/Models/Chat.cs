using Amazon.DynamoDBv2.DataModel;

namespace Learner.Shared.Models
{

    [DynamoDBTable("chats")]
    public class Chat
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }

        [DynamoDBProperty("creator_id")]
        public int CreatorId { get; set; }

        [DynamoDBProperty("title")]
        public string? Title { get; set; }


    }
}
