```powershell
Install-Package Moq
```

This example is taken directly from the [moq4 github repo](https://github.com/Moq/moq4).  It should be enough to give you an idea of how to use mock.  If more details are needed review the moq github repo link above.

```c#
  var mock = new Mock<ILoveThisFramework>();

  // WOW! No record/replay weirdness?! :)
  mock.Setup(framework => framework.DownloadExists("2.0.0.0"))
      .Returns(true);

  // Hand mock.Object as a collaborator and exercise it, 
  // like calling methods on it...
  ILoveThisFramework lovable = mock.Object;
  bool download = lovable.DownloadExists("2.0.0.0");

  // Verify that the given method was indeed called with the expected value at most once
  mock.Verify(framework => framework.DownloadExists("2.0.0.0"), Times.AtMostOnce());
```