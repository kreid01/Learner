using Amazon.DynamoDBv2.DataModel;

namespace Learner.Shared.Models
{

    [DynamoDBTable("channels")]
    public class Channel
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }

        [DynamoDBProperty("creator_id")]
        public int CreatorId { get; set; }

        [DynamoDBProperty("title")]
        public string Title { get; set; }


        [DynamoDBProperty("is_private")]
        public bool IsPrivate { get; set; }


        [DynamoDBProperty("password")]
        public string? Password { get; set; }


    }
}
