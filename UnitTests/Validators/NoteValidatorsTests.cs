using CQRSMediator.Commands.Notes.BindTags;
using CQRSMediator.Commands.Notes.CreateNote;
using CQRSMediator.Commands.Notes.DeleteNote;
using CQRSMediator.Commands.Notes.UpdateNote;
using CQRSMediator.Queries.Notes.GetNote;
using CQRSMediator.Queries.Notes.GetNoteTag;
using CQRSMediator.Validators.Notes;

namespace UnitTests.Validators;

public class NoteValidatorsTests
{
    [Theory]
    [InlineData("text", null)]
    [InlineData(null, "Title")]
    [InlineData(null, null)]
    [InlineData("", "")]
    public void CreateValidator_ShouldHaveError(string text, string title)
    {
        //Arrange
        CreateNoteValidator _validator = new();
        var command = new CreateNoteCommand() { Text = text, Title = title };
        //Act
        var result = _validator.Validate(command);
        //Assert
        Assert.False(result.IsValid);
        if (string.IsNullOrEmpty(text))
            Assert.Contains("Text is required.", result.Errors.Select(e => e.ErrorMessage));
        if (string.IsNullOrEmpty(title))
            Assert.Contains("Title is required.", result.Errors.Select(e => e.ErrorMessage));
    }

    [Fact]
    public void CreateValidator_ShouldPass()
    {
        //Arrange
        CreateNoteValidator _validator = new();
        var command = new CreateNoteCommand() { Text = "text", Title = "title" };
        //Act
        var result = _validator.Validate(command);
        //Assert
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void deleteValidator_ShouldHaveError(int id)
    {
        //Arrange
        DeleteNoteValidator _validator = new();
        var command = new DeleteNoteCommand() { Id = id };
        //Act
        var result = _validator.Validate(command);
        //Assert
        Assert.False(result.IsValid);
        if (id == 0)
            Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
        if (id < 0)
            Assert.Contains("Id must be greater tehat 0.", result.Errors.Select(e => e.ErrorMessage));
    }

    [Fact]
    public void deleteValidator_ShouldPass()
    {
        //Arrange
        DeleteNoteValidator _validator = new();
        var command = new DeleteNoteCommand() { Id = 4 };
        //Act
        var result = _validator.Validate(command);
        //Assert
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData(0, 1, 2, 3)]
    [InlineData(0, 0)]
    [InlineData(3, 0)]
    public void BindNoteValidator_ShouldHaveError(int noteId, params int[] tagsIds)
    {
        //Arrange
        List<int> tagsIdsList = new List<int>(tagsIds);
        BindNoteValidator _validator = new();
        var command = new BindTagsToNoteCommand() { NoteId = noteId, TagsIds = tagsIdsList };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        if (noteId == 0)
            Assert.Contains("NoteId is required.", result.Errors.Select(e => e.ErrorMessage));
        if (tagsIdsList.Count == 0)
            Assert.Contains("TagIds is required", result.Errors.Select(e => e.ErrorMessage));
        if (tagsIdsList.Any(tag => tag <= 0))
            Assert.Contains("TagIds must be greate than 0.", result.Errors.Select(e => e.ErrorMessage));
    }

    [Fact]
    public void BindNoteValidator_ShouldPass()
    {
        //Arrange
        BindNoteValidator _validator = new();
        var command = new BindTagsToNoteCommand() { NoteId = 4, TagsIds = new List<int> { 1, 2 } };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData(0, "","")]
    [InlineData(0, null,"")]
    [InlineData(0, "",null)]
    [InlineData(0, null,null)]
    [InlineData(0, "Text","")]
    [InlineData(2, "","Title")]
    public void UpdateValidator_ShouldHaveError(int id, string text, string title)
    {
        //Arrange
        UpdateNoteValidator _validator = new();
        var command = new UpdateNoteCommand() {Id=id, Text=text, Title=title};

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
    }

    [Fact]
    public void UpdateValidator_ShouldPass()
    {
        //Arrange
        UpdateNoteValidator _validator = new();
        var command = new UpdateNoteCommand() { Id = 1, Text = "text", Title = "title" };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetNoteByIdValidator_ShouldHaveError(int id)
    {
        //Arrange
        GetNoteByIdValidator _validator = new();
        var command = new GetNoteQuery() { Id = id};

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        if (id == 0)
            Assert.Contains("Id is required.", result.Errors.Select(e => e.ErrorMessage));
        if (id<0)
            Assert.Contains("Id must be greater than 0.", result.Errors.Select(e => e.ErrorMessage));
    }

    [Fact]
    public void GetNoteByIdValidator_ShouldPass()
    {
        //Arrange
        GetNoteByIdValidator _validator = new();
        var command = new GetNoteQuery() { Id = 3 };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GetNoteTagByIdValidator_ShouldHaveError(int noteId)
    {
        //Arrange
        GetNoteTagByIdValidator _validator = new();
        var command = new GetNoteTagQuery() { NoteId = noteId };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        if (noteId == 0)
            Assert.Contains("NoteId is required.", result.Errors.Select(e => e.ErrorMessage));
        if (noteId < 0)
            Assert.Contains("NoteId must be greater than 0.", result.Errors.Select(e => e.ErrorMessage));
    }

    [Fact]
    public void GetNoteTagByIdValidator_ShouldPass()
    {
        //Arrange
        GetNoteTagByIdValidator _validator = new();
        var command = new GetNoteTagQuery() { NoteId = 3 };

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }

}