using CQRSMediator.Commands.Tags.CreateTag;
using CQRSMediator.Commands.Tags.DeleteTag;
using CQRSMediator.Commands.Tags.UpdateTag;
using CQRSMediator.Queries.Tags.GetTag;
using CQRSMediator.Validators.Tags;

namespace UnitTests.Validators
{
    public class TagValidatorTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateValidator_ShouldHaveError(string name)
        {
            //Arrange
            CreateTagValidator _validator = new();

            var command = new CreateTagCommand()
            {
                Name = name
            };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (string.IsNullOrEmpty(name))
                Assert.Contains("Name is required.", result.Errors.Select(e => e.ErrorMessage)); ;
        }

        [Fact]
        public void CreateValidator_ShouldPass()
        {
            //Arrange
            CreateTagValidator _validator = new();
            var command = new CreateTagCommand() { Name = "Name1" };
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
            DeleteTagValidator _validator = new();
            var command = new DeleteTagCommand() { Id = id };
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
            DeleteTagValidator _validator = new();
            var command = new DeleteTagCommand() { Id = 4 };
            //Act
            var result = _validator.Validate(command);
            //Assert
            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(0, "")]
        [InlineData(0, null)]
        [InlineData(2, "")]
        public void UpdateTagValidator_ShouldHaveError(int id, string name)
        {
            //Arrange
            UpdateTagValidator _validator = new();
            var command = new UpdateTagCommand() { Id = id, Name = name };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.False(result.IsValid);
            if (id == 0)
                Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
            if (string.IsNullOrEmpty(name))
                Assert.Contains("Name is required.", result.Errors.Select(e => e.ErrorMessage));
        }

        [Fact]
        public void UpdateTagValidator_ShouldPass()
        {
            //Arrange
            UpdateTagValidator _validator = new();
            var command = new UpdateTagCommand() { Id = 1, Name = "Name1" };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetTagByIdValidator_ShouldHaveError(int id)
        {
            //Arrange
            GetByIdTagValidator _validator = new();
            var command = new GetTagQuery() { Id = id };

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
        public void GetTagByIdValidator_ShouldPass()
        {
            //Arrange
            GetByIdTagValidator _validator = new();
            var command = new GetTagQuery() { Id = 3 };

            //Act
            var result = _validator.Validate(command);

            //Assert
            Assert.True(result.IsValid);
        }
    }
}
