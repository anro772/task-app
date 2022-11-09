namespace UnitTests;

public class TasksControllerTests
{
    [Fact]
    public void GetTask_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetTaskByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((AppUser)null);
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.GetTask(1);
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
    [Fact]
    public void GetTasks_WithUnexistingItems_ReturnsNotFound()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetTaskListQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AppUser>());
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.GetTasks();
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}