using Learner.Server.Services;
using Learner.Shared.Models;

namespace Learner.Tests
{
    public class FilterTests
    {
        [Fact]
        public void IsCorrectPassword_ReturnsTrueIfPasswordsMatch()
        {
            //Arrange
            bool expected = true;

            var service = new ControllerService();
            //Act
            bool actual = service.IsCorrectPassword("password", "password");

            //Asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FilterMessagesForChat_ReturnsCorrectMessages()
        {
            //Arrange
            var messages = new List<Message>
            {
                 new Message()
                 {
                     ChatId= 1,
                     CreatedDate = "Today",
                     Id= 1,
                     Content = "Message",
                     PosterName = "Test"

                 },
                    new Message()
                 {
                     ChatId= 1,
                     CreatedDate = "Today",
                     Id= 2,
                     Content = "Message",
                     PosterName = "Test"

                 },
                       new Message()
                 {
                     ChatId= 3,
                     CreatedDate = "Today",
                     Id= 3,
                     Content = "Message",
                     PosterName = "Test"

                 },
            };

            //Act
            var filter = new ControllerService();

            var expected = filter.FilterMessagesForChat(messages, 1).Count();

            var result = 2;

            //Asserts

            Assert.Equal(expected, result);

        }
    }
}