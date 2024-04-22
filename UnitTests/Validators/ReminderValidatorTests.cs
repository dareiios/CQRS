using CQRSMediator.Commands.Reminders.BindTags;
using CQRSMediator.Commands.Reminders.CreateReminder;
using CQRSMediator.Commands.Reminders.DeleteReminder;
using CQRSMediator.Commands.Reminders.UpdateReminder;
using CQRSMediator.Queries.Reminders.GetReminder;
using CQRSMediator.Queries.Reminders.GetReminderTag;
using CQRSMediator.Validators.Reminders;

namespace UnitTests.Validators
{
    public class ReminderValidatorTests
    {
        [Theory]
        [InlineData("text", null, true)]
        [InlineData(null, "Title", true)]
        [InlineData(null, null, false)]
        [InlineData("", "", false)]
        public void CreateValidator_ShouldHaveError(string text, string title, bool isDateNull)
        {
            //Arrange
            CreateReminderValidator _validator = new();
            DateTime? dateToRemind = isDateNull ? null : new DateTime(2023, 2, 2, 12, 15, 0);

            var command = new CreateReminderCommand()
            {
                Text = text,
                Title = title,
                DateToRemind = dateToRemind
            };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (string.IsNullOrEmpty(text))
                Assert.Contains("Text is required.", result.Errors.Select(e => e.ErrorMessage));
            if (string.IsNullOrEmpty(title))
                Assert.Contains("Title is required.", result.Errors.Select(e => e.ErrorMessage));
            if (isDateNull)
                Assert.Contains("DateToRemind is required.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void CreateValidator_ShouldPass()
        {
            //Arrange
            CreateReminderValidator _validator = new();
            var command = new CreateReminderCommand() { Text = "text", Title = "title", DateToRemind = DateTime.Now };
            //Act
            var result = _validator.Validate(command);
            //Assert
            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DeleteValidator_ShouldHaveError(int id)
        {
            //Arrange
            DeleteReminderValidator _validator = new();
            var command = new DeleteReminderCommand() { Id = id };
            //Act
            var result = _validator.Validate(command);
            //Assert
            Assert.False(result.IsValid);
            if (id == 0)
                Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
            if (id < 0)
                Assert.Contains("Id must be greater than 0.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void DeleteValidator_ShouldPass()
        {
            //Arrange
            DeleteReminderValidator _validator = new();
            var command = new DeleteReminderCommand() { Id = 4 };
            //Act
            var result = _validator.Validate(command);
            //Assert
            Assert.True(result.IsValid);
        }



        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 0)]
        [InlineData(3, 0)]
        public void BindReminderValidator_ShouldHaveError(int reminderId, params int[] tagsIds)
        {
            //Arrange
            List<int> tagsIdsList = new List<int>(tagsIds);
            BindReminderValidator _validator = new();
            var command = new BindTagsToReminderCommand() { ReminderId = reminderId, TagsIds = tagsIdsList };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (reminderId == 0)
                Assert.Contains("ReminderId is required.", result.Errors.Select(e => e.ErrorMessage));
            if (tagsIdsList.Count == 0)
                Assert.Contains("TagIds is required", result.Errors.Select(e => e.ErrorMessage));
            if (tagsIdsList.Any(tag => tag <= 0))
                Assert.Contains("TagIds must be greate than 0.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void BindReminderValidator_ShouldPass()
        {
            //Arrange
            BindReminderValidator _validator = new();
            var command = new BindTagsToReminderCommand() { ReminderId = 4, TagsIds = new List<int> { 1, 2 } };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }



        [Theory]
        [InlineData(0, "", "", null)]
        [InlineData(0, null, "", null)]
        [InlineData(0, "", null, null)]
        [InlineData(0, null, null, null)]
        [InlineData(0, "Text", "", null)]
        [InlineData(2, "", "Title", null)]
        public void UpdateReminderValidator_ShouldHaveError(int id, string text, string title, DateTime? date)
        {
            //Arrange
            UpdateReminderValidator _validator = new();
            var command = new UpdateReminderCommand() { Id = id, Text = text, Title = title, DateToRemind = date };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (id == 0)
                Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
            if (string.IsNullOrEmpty(text))
                Assert.Contains("Text is required.", result.Errors.Select(e => e.ErrorMessage));
            if (string.IsNullOrEmpty(title))
                Assert.Contains("Title is required.", result.Errors.Select(e => e.ErrorMessage));
            if (date == null)
                Assert.Contains("DateToRemind is required.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void UpdateReminderValidator_ShouldPass()
        {
            //Arrange
            UpdateReminderValidator _validator = new();
            var command = new UpdateReminderCommand() { Id = 1, Text = "text", Title = "title", DateToRemind = new(2021, 2, 3, 13, 14, 0) };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetReminderByIdValidator_ShouldHaveError(int id)
        {
            //Arrange
            GetReminderByIdValidator _validator = new();
            var command = new GetReminderQuery() { Id = id };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (id == 0)
                Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
            if (id < 0)
                Assert.Contains("Id must be greater than 0.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void GetReminderByIdValidator_ShouldPass()
        {
            //Arrange
            GetReminderByIdValidator _validator = new();
            var command = new GetReminderQuery() { Id = 3 };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetReminderTagByIdValidator_ShouldHaveError(int reminderId)
        {
            //Arrange
            GetReminderTagByIdValidator _validator = new();
            var command = new GetReminderTagQuery() { ReminderId = reminderId };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (reminderId == 0)
                Assert.Contains("ReminderId is required.", result.Errors.Select(e => e.ErrorMessage));
            if (reminderId < 0)
                Assert.Contains("ReminderId must be greater than 0.", result.Errors.Select(e => e.ErrorMessage));
        }


        [Fact]
        public void GeReminderTagByIdValidator_ShouldPass()
        {
            //Arrange
            GetReminderTagByIdValidator _validator = new();
            var command = new GetReminderTagQuery() { ReminderId = 3 };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }
    }
}
