using Business.Helpers;
namespace Tests.Helpers;

public class IdGenerator_Test
{
    [Fact]
    public void Generate_ShouldReturnString()
    {       
        // Act
        var result = IdGenerator.Generate();
        // Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
