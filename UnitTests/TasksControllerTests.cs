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
        var result = controller.GetTask(2);
        Console.WriteLine(result.Result);
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void GetTasks_WithExistingItems_ReturnsOk()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetTaskListQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AppUser>());
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.GetTasks();
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void AddTask_WithValidItem_ReturnsOk()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<AddTaskCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AppUser());
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.AddTask(new AppUser());
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void DeleteTask_WithValidItem_ReturnsOk()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<DeleteTaskCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AppUser());
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.DeleteTask(1);
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void DeleteTask_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<DeleteTaskCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((AppUser)null);
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.DeleteTask(1);
        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void UpdateTask_WithValidItem_ReturnsOk()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<UpdateTaskCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AppUser());
        var controller = new TasksController(mockMediator.Object);
        // Act
        var result = controller.UpdateTask(new AppUser(), 1);
        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }
}